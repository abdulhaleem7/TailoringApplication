var dropcloths = document.getElementById('getCategory');
console.log("usajdk")
var getUrl =   'https://localhost:7060/api/Category/GetAll'
async function getJSON () {
    const response = await fetch(getUrl);
    let d = response.json();
    console.log(d);
     return (d);
}

console.log("uydgghasgghsa")
let  CategoryNameDropDownOnCustomerPage = async ()  => {
    let fetchCloth = getJSON();
   let s = await getJSON();
   console.log(s);
   console.log("1");
   s.data.forEach(element => {
       console.log(element.id);
       dropcloths.innerHTML += `   
       <a  class="nav-item nav-link" id="${element.id}">${element.name} dress</a>
       `
   });
   ImageLinkOnCustomerFirstPage();

}

const ImageLinkOnCustomerFirstPage =()=>{
    let editClick = document.querySelectorAll(".nav-item")
     console.log("loading....")
    editClick.forEach(x => {
         x.addEventListener("click",(f)=>{
             console.log(f.target.id);
             window.location.href =`/Customer/Cloth.html?id=${f.target.id}`
         })
     })
     
 }

 CategoryNameDropDownOnCustomerPage();