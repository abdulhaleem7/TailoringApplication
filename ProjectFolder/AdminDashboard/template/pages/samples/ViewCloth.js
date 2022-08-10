console.log("seen")
var get = document.getElementById('test1');

var id;
if(window.location.href.split('=')[1]== undefined)
{
    id = localStorage.getItem("redirect");
    console.log("redirect", id);
} 
else
{
    id = window.location.href.split('=')[1];
    localStorage.setItem("redirect",id);
}
console.log("5"); 
console.log(id);
async function Clothes () {
    console.log("seen1")
    const response = await fetch(`https://localhost:7060/api/Cloth/GetAllClothByCategory/${id}`);
    let d = response.json();
    console.log(d);
     return d;

    }

    let displayClothes = async ()  => {
       let s = await Clothes();
       console.log(s);
       console.log("1");
       console.log(s.data);
     for(var dat of s.data){
         console.log(dat.na)
         get.innerHTML+=`
         <div >
            <div>
            <img id="edit1" class="my-btn" src="https://localhost:7060/ClothImage/${dat.picture}"> 
            <h4>
            <span><button class="my-btn btn-success"  id="${dat.id}">${dat.name}</button></span>
            <span>${dat.price}</span>
            </h4>
            </div>
        </div>
         `
     }
     redirect();
    }
    
    const redirect =()=>{
       let clicking = document.querySelectorAll(".my-btn");
        console.log("loading....")
       clicking.forEach(x => {
            x.addEventListener("click",(f)=>{
                console.log(f.target.id);
                window.location.href =`/template/pages/samples/ViewDesign.html?id=${f.target.id}`
            })
        })
        
    }
    
    
    displayClothes();
    