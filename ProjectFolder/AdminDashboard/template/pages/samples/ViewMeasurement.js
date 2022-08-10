console.log("seen")
var get = document.getElementById('test3');

console.log("5"); 
async function Clothes () {
    console.log("seen1")
    const response = await fetch(`https://localhost:7060/api/Measurement/GetAll`);
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
         <div>
            <div id="edit5">
            <img id="edit4" class="my-btn" src="https://localhost:7060/measurement/${dat.picture}"> 
            
            <h4>
            
            <span><button class="my-btn btn-success"  id="${dat.id}">${dat.name}</button></span>
            </h4>
            
            </div>
        </div>
         `
     }
     
    }
     
    displayClothes();
    