let idd = localStorage.getItem("UserId");
let CartNumber = document.getElementById('CartNumber');
let cartsummary = document.getElementById('cartSummary');
let cartsummarys = document.getElementById('cartSummarys');

let cart = document.getElementById('Customercart')
let locations = document.getElementById('location');
let pay = document.querySelector('#pay')

async function FetchOrderByCustomerId () {
    console.log("seen1")
    const response = await fetch(`https://localhost:7060/OrderByCustomer/${idd}`);
    let d = response.json();
     return d;

    }
    async function FetchCartByCustomerId () {
        const response = await fetch(`https://localhost:7060/api/Cart/GetCartByCustomerId/${idd}`);
        let d = response.json();
        console.log(d);
         return d;
    
        }

    
    
    var count = 0;
    let displayOrderOnCustomerPage = async ()  => {
       let s = await FetchOrderByCustomerId();
       var totalprice=0;
     for(var dat of s.data){
        totalprice+= dat.totalPrice;
        count++;
         cart.innerHTML+=`
         <tr>
         <td class="align-middle"><img src="https://localhost:7060/design/${dat.designImage}" alt="" style="width: 50px;">Colourful stylish ${dat.designName}</td>
            <td class="align-middle">#${dat.price}</td>
            <td class="align-middle">
                <div class="input-group quantity mx-auto" style="width: 100px;">
               
                <input type="number" class="form-control form-control-sm bg-secondary text-center" min="1" value="${dat.quantity}">
                
        </div>
            </td>
            <td class="align-middle">#${dat.totalPrice}</td>
            <td class="align-middle"><button class="btn btn-secondary" id="${dat.id}">remove</button></td>
            </tr
         `
       
     }   
     cartsummary.innerHTML=`<div class="d-flex justify-content-between mb-3 pt-1">
     <h6 class="font-weight-medium">Total Amount</h6>
     <h6 class="font-weight-medium">#${totalprice}</h6>
     </div>`
     cartsummarys.innerHTML = `
        <div class="d-flex justify-content-between mb-3 pt-1">
            <h6 class="font-weight-medium">Subtotal</h6>
            <h6 class="font-weight-medium">#${totalprice}</h6>
        </div>
        <div class="d-flex justify-content-between">
            <h6 class="font-weight-medium">Shipping</h6>
            <h6 class="font-weight-medium">#1000</h6>
        </div>
        `
     remove();
 }
console.log(count);
 CartNumber.innerHTML=`
     <i class="fas fa-shopping-cart text-primary"></i>
     <span class="badge">${count}</span>
     `
  let getCart = async ()=>{
      let x = await FetchCartByCustomerId();

        
     
  }
 
  const remove =()=>{
    let clicking = document.querySelectorAll(".btn");
     console.log("loading....")
    clicking.forEach(x => {
         x.addEventListener("click",(f)=>{
             console.log(f.target.id);
             fetch(`https://localhost:7060/DeleteOrdersInCart/${f.target.id}`,
             {
                 
                 method: "POST",
             })
             .then(res => res.json())
             .then(data =>{
                 if(data.status === false){
                     alert(data.message)
                 }
                 else if(data.status == true){
                  alert(data.message)
                  document.location.reload(true);
                 }
                       
             })
         })
     })
     
 }
    function payment() {
        fetch(`https://localhost:7060/api/Payment/Create/${idd}`,
        {
            method: "POST",
            headers: {
                "content-type": "application/json"
            },
        })
        .then(res=>res.json())
        .then(data=> {
            if(data.status==false)
            {
                window.alert(data.message)
            }
            window.location.href = data.data.authorization_url 
        })
        
    }

    displayOrderOnCustomerPage();
    getCart();