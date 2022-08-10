console.log("seen")
var get = document.getElementById('clothes');

    var id = window.location.href.split('=')[1];
    localStorage.setItem("redirect",id);

console.log("5"); 
console.log(id);
async function ClothId () {
    console.log("seen1")
    const response = await fetch(`https://localhost:7060/api/Cloth/GetAllClothByCategory/${id}`);
    let d = response.json();
    console.log(d);
     return d;

    }

    let displayCloth = async ()  => {
       let s = await ClothId();
     for(var dat of s.data){
         get.innerHTML+=`
         <div class="col-lg-4 col-md-6 col-sm-12 pb-1">
            <div class="card product-item border-0 mb-4">
                <div class="card-header product-img position-relative overflow-hidden bg-transparent border p-0">
                    <img class="btn img-fluid w-100" id="${dat.id}" src="https://localhost:7060/ClothImage/${dat.picture}" alt="">
                </div>
                <div class="card-body border-left border-right text-center p-0 pt-4 pb-3">
                    <h6 class="text-truncate mb-3">Colorful Stylish ${dat.name} dress</h6>
                    <div class="d-flex justify-content-center">
                        <h6>#${dat.price}</h6><h6 class="text-muted ml-2"></h6>
                    </div>
                </div>
            </div>
         </div>
         `
     }
     redirect();
    }
    
    const redirect =()=>{
       let clicking = document.querySelectorAll(".btn");
        console.log("loading....")
       clicking.forEach(x => {
            x.addEventListener("click",(f)=>{
                window.localStorage.setItem("ClothId", f.target.id);
                console.log(f.target.id);
                
                window.location.href =`/Customer/shop.html?id=${f.target.id}`
            })
        })
        
    }
    
    
displayCloth();
    