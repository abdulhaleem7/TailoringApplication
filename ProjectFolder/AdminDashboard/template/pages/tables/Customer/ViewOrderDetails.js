var viewDetails = document.getElementById("viewDetails")
let idd = localStorage.getItem("UserId");

async function GetAllOrders(){
    const getOrders = await fetch(`https://localhost:7060/api/Cart/GetAllCartByCustomerId/${idd}`);
     var get = getOrders.json();
     console.log(get);
     return get;
}

let DisplayOrders = async() =>{
    var gets = await GetAllOrders();
    for(var dat of gets.data)
    {
        console.log(dat);

        viewDetails.innerHTML+=`
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
        <td><button id="${dat.id}" class="btn badge-opacity-success">view details</button></td>
        <td><div class="badge badge-opacity-success">pending</div></td>
        </tr>
        `
    }

    redirect1();
}


const redirect1 =()=>{
    let clicking = document.querySelectorAll(".btn");
     console.log("loading....")
    clicking.forEach(x => {
         x.addEventListener("click",(f)=>{
             console.log(f.target.id);
             window.location.href =`/template/pages/tables/Customer/viewItemsDetails.html?id=${f.target.id}`
         })
     })
     
 }


DisplayOrders();