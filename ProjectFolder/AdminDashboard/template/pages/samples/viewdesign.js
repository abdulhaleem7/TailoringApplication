console.log("seen")
var get = document.getElementById('test2');

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
    const response = await fetch(`https://localhost:7060/api/Design/GetDesignByClothId/${id}`);
    let d = response.json();
    console.log(d);
     return d;

    }

    let displayClothes = async ()  => {
        let fetchCloth = Clothes();
       let s = await Clothes();
       console.log(s);
       console.log("1");
       console.log(s.data);
     for(var dat of s.data){
         console.log(dat.na)
         get.innerHTML+=`
         <div >
            <div>
            <img id="edit1" class="my-btn" src="https://localhost:7060/Design/${dat.picture}">
            <img id="edit1" class="my-btn"src="https://localhost:7060/Design/${dat.picture2}">  
            <h4>
            <span>${dat.name}</button></span>
            </h4>
            </div>
        </div>
         `
     }
    }
    
    
    displayClothes();
    