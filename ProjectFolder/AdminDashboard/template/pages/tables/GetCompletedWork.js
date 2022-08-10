var viewCompleted = document.getElementById("viewCompleted")

async function GetAllOrders(){
    const getOrders = await fetch(`https://localhost:7060/api/Cart/GetCompletedCart`);
     var get = getOrders.json();
     console.log(get);
     return get;
}

let DisplayOrders = async() =>{
    var gets = await GetAllOrders();
    for(var dat of gets.data)
    {
        console.log(dat);

        viewCompleted.innerHTML+=`
        <tr>
        
        <td>
            <div>
                <h6>${dat.customerName}</h6>
            </div>
            </div>
        </td>
        <td>
            <h6>${dat.sendDeliveryDate}</h6>
        </td>
        <td>
        <h6>${dat.count}</h6>
        </td>
        
        <td><button id="${dat.customerId}" class="my-btn badge-opacity-success">mesurement</button></td>
        <td><button id="${dat.id}" class="my badge-opacity-success">details</button></td>
        <td><div class="badge badge-opacity-primary">completed</div></td>
        </tr>
        `
    }
    getmeasuremnet();
    redirect1();
    //update();
}

const getmeasuremnet =()=>{
    let clicking = document.querySelectorAll(".my-btn");
     console.log("loading....")
    clicking.forEach(x => {
         x.addEventListener("click",(f)=>{
             console.log(f.target.id);
             window.location.href =`/template/pages/tables/customerMeasurement.html?id=${f.target.id}`
         })
     })
     
 }
 
const redirect1 =()=>{
    let clicking = document.querySelectorAll(".my");
     console.log("loading....")
    clicking.forEach(x => {
         x.addEventListener("click",(f)=>{
             console.log(f.target.id);
             window.location.href =`/template/pages/tables/GetCompleorderByCartId.html?id=${f.target.id}`
         })
     })
     
 }


//  const update =()=>{
//     let clicking = document.querySelectorAll(".btn");
//      console.log("loading....")
//     clicking.forEach(x => {
//          x.addEventListener("click",(f)=>{
//              console.log(f.target.id);
//              fetch(`https://localhost:7060/UpdateOrdersInCartTOCompleted/${f.target.id}`,
//              {
                 
//                  method: "POST",
//              })
//              .then(res => res.json())
//              .then(data =>{
//                  if(data.status === false){
//                      alert(data.message)
//                  }
//                  else if(data.status == true){
//                   alert(data.message)
//                   document.location.reload(true);
//                  }
                       
//              })
//          })
//      })
     
//  }

DisplayOrders();