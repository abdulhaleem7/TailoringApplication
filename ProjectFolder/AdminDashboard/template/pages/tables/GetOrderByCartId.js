var detailsOrder = document.getElementById('detailsOrder');
var id = window.location.href.split("=")[1];

async function GetOrderByCartId() {
    const getOrders = await fetch(`https://localhost:7060/GetOrderByCartId/${id}`)
    let s = getOrders.json();
    console.log(s);
    return s;
}


let displayDetails = async ()=>{
    var get = await GetOrderByCartId();
    for(var x of get.data)
    {
        console.log(x);
        detailsOrder.innerHTML+=`
            <tr>
            <td class="align-middle"><img src="https://localhost:7060/Design/${x.designImage}"  alt="" style="width: 50px ; height: 60px; border-radius:0px; ">${x.designName}</td>

        <td>
           ${x.colourName}
        </td>
        <td>
            <div class="progress">
            <div class="progress-bar bg-warning" role="progressbar" style="width: ${x.dateDiff*10}%" aria-valuenow="${x.dateDiff*10}" aria-valuemin="0" aria-valuemax="100"></div>
            </div>
        </td>
        <td>
            #${x.totalPrice}
        </td>
        <td>
            ${x.deliveryDae}
        </td>
        </tr>
        `
    }
}


displayDetails();