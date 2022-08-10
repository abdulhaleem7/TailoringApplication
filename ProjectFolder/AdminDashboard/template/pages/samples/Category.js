var get = document.getElementById('test1'); 
var getUrl =   'https://localhost:7060/api/Category/GetAll'
async function getJSON () {
    const response = await fetch(getUrl);
    let d = response.json();
    console.log(d);
     return (d);
}

let Category = async () => {
    let s = await getJSON();
    s.data.forEach(element => {
        categorydropdown.innerHTML +=`
        <li class="nav-item"> <button class="nav-link" id="${element.id}" >${element.name}</button></li>
         
        `
    })
    ImageLinkOnCustomerFirstPage();

}

const ImageLinkOnCustomerFirstPage =()=>{
    let editClick = document.querySelectorAll(".nav-link")
     console.log("loading....")
    editClick.forEach(x => {
         x.addEventListener("click",(f)=>{
             console.log(f.target.id);
             window.location.href =`/template/pages/samples/ViewCloth.html?id=${f.target.id}`
         })
     })
     
 }

 
Category();