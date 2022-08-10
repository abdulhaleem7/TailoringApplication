var viewhistory = document.getElementById("viewhistory")
let id = localStorage.getItem("UserId");

async function GetAllOrders(){
    const getOrders = await fetch(`https://localhost:7060/api/Cart/GetAllReceivedCartByCustomer/${id}`);
     var get = getOrders.json();
     console.log(get);
     return get;
}

let DisplayOrders = async() =>{
    var gets = await GetAllOrders();
    for(var dat of gets.data)
    {
        console.log(dat);

        viewhistory.innerHTML+=`
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
        <td><button id="${dat.id}" class="badge badge-opacity-success">details</button></td>
        </tr>
        `
    }

    redirect1();
    //update();
}


const redirect1 =()=>{
    let clicking = document.querySelectorAll(".badge");
     console.log("loading....")
    clicking.forEach(x => {
         x.addEventListener("click",(f)=>{
             console.log(f.target.id);
             window.location.href =`/template/pages/tables/Customer/ViewItemHistory.html?id=${f.target.id}`
         })
     })
     
 }


//  const update =()=>{
//     let clicking = document.querySelectorAll(".btn");
//      console.log("loading....")
//     clicking.forEach(x => {
//          x.addEventListener("click",(f)=>{
//              console.log(f.target.id);
//              fetch(`https://localhost:7060/UpdateOrdersInCartTOProccessing/${f.target.id}`,
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