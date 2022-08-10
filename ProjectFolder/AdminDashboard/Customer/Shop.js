console.log("seen")
var get = document.getElementById('myCloths');

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
window.localStorage.setItem("clothid",id);
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
            <div class="col-lg-4 col-md-6 col-sm-12 pb-1">
                <div class="card product-item border-0 mb-4">
                    <div class="card-header product-img position-relative overflow-hidden bg-transparent border p-0">
                        <img class="btn img-fluid w-100" id="${dat.id}" src="https://localhost:7060/Design/${dat.picture}" alt="">
                    </div>
                    <div class="card-body border-left border-right text-center p-0 pt-4 pb-3">
                        <h6 class="text-truncate mb-3">${dat.name}</h6>
                    </div>
                </div>
            </div>
            <div class="col-lg-4 col-md-6 col-sm-12 pb-1">
                <div class="card product-item border-0 mb-4">
                    <div class="card-header product-img position-relative overflow-hidden bg-transparent border p-0">
                        <img class="btn img-fluid w-100" id="${dat.id}" src="https://localhost:7060/Design/${dat.picture2}" alt="">
                    </div>
                    <div class="card-body border-left border-right text-center p-0 pt-4 pb-3">
                        <h6 class="text-truncate mb-3">${dat.name}</h6>
                    </div>
                   
                </div>
            </div>
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
                 window.location.href =`/Customer/detail.html?id=${f.target.id}`
             })
         })
         
     }
    
    displayClothes();
    