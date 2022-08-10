console.log("seen")
var get = document.getElementById('measurement');
const orderform = document.querySelector('#orderform')
var inputmeasurement = document.getElementById('test8');
var mee = document.getElementById('mee');
var get3 = document.getElementById('innerColour')
var getdesignid = document.getElementById('designid');
var idd = localStorage.getItem("ClothId");
var userid = localStorage.getItem("UserId")
console.log("hfuhshu",userid);
console.log("userid",userid)

var desid = window.location.href.split('=')[1];
localStorage.setItem("redirect",desid);





async function ClothId () {
    console.log("seen1")
    const response = await fetch(`https://localhost:7060/api/Design/GetById/${desid}`);
    let d = response.json();
    console.log(d);
     return d;

    }
    async function mesurements () {
        console.log("seen1")
        const response = await fetch(`https://localhost:7060/api/Measurement/GetMeasurementByClothId/${idd}`);
        let d = response.json();
        console.log(d);
         return d;
    
        }
        
        async function getmeasurementbycustomer (){
            
                const s = await mesurements();
                let y;
                
              for(var dat of s.data){
                y = dat.name
                break;
              }
             
            const response = await fetch(`https://localhost:7060/GetMeasuremenvalueByCustomerId/${userid}/${y}`);
            let d = response.json();
            console.log("true",d)
            return d;
        }


         let displaygetmeasurementbycustomer = async ()  => {
            console.log("hysyhhjjhjk")
         let s = await getmeasurementbycustomer();
       if(s.status == false)
       {
        displayColours();
        displayCloth();
        injectDesignId();
        displayMeasurement();
        orderform.addEventListener('submit',(e)=>{
            e.preventDefault();
            let sendForm = new FormData(orderform);
                
                fetch(`https://localhost:7060/CreateOrderForItem/${userid}`,
                {
                    
                    method: "POST",
                    body: sendForm
                })
                .then(res => res.json())
                .then(data =>{
                    if(data.status == false){
                        alert(data.message)
                    }
                    else if(data.status == true){
                    alert(data.message)
                    window.location.reload();
                    }
                        
                })
            });
           
       }
       else
       {
       let a = window.confirm("are u using ur formal measurement");
       if (a == true) {
        displayColours();
        displayCloth();
        injectDesignId();    
        orderform.addEventListener('submit',(e)=>{
            e.preventDefault();
            let sendForm = new FormData(orderform);
                
                fetch(`https://localhost:7060/CreateOrderForItem/${userid}`,
                {
                    
                    method: "POST",
                    body: sendForm
                })
                .then(res => res.json())
                .then(data =>{
                    if(data.status == false){
                        alert(data.message)
                    }
                    else if(data.status == true){
                    alert(data.message)
                    window.location.reload();
                    }
                        
                })
            });

       } else {
           
        displayColours();
        displayCloth();
        injectDesignId();  
        displayMeasurement();  
        orderform.addEventListener('submit',(e)=>{
            e.preventDefault();
            let sendForm = new FormData(orderform);
                
                fetch(`https://localhost:7060/CreateOrderForItem/${userid}`,
                {
                    
                    method: "POST",
                    body: sendForm
                })
                .then(res => res.json())
                .then(data =>{
                    if(data.status == false){
                        alert(data.message)
                    }
                    else if(data.status == true){
                    alert(data.message)
                    window.location.reload();
                    }
                        
                })
            });

       }
       
       }
     }
        async function colours () {
            console.log("seen1")
            const response = await fetch(`https://localhost:7060/api/Colour/GetAll`);
            let d = response.json();
            console.log(d);
             return d;
        
            }


            let displayColours = async ()  => {
                let s = await colours();
                console.log(s.data);
              for(var dat of s.data){
                  console.log(dat.na)
                  get3.innerHTML+=`
                  <div class="custom-control custom-radio custom-control-inline">
                        <input type="radio" class="custom-control-input"value="${dat.id}" id="color-${dat.id}" name="ColourId" required>
                        <label class="custom-control-label" for="color-${dat.id}">${dat.name}</label>
                        <img id="editimage" src="https://localhost:7060/Colour/${dat.image}" alt="">
                    </div>
                  `
              }
             }
           

    let displayCloth = async ()  => {
       let s = await ClothId();
       console.log(s.data);
         
         get.innerHTML =`
            <div class="carousel-item active" >
                <img class="w-100 h-100" src="https://localhost:7060/design/${s.data.picture}" alt="Image">
            </div>
            <div class="carousel-item" >
             <img class="w-100 h-100" src="https://localhost:7060/design/${s.data.picture2}" alt="Image">
         </div>
         `
     }
   
     let displayMeasurement = async ()  => {
       let s = await mesurements();
     for(var dat of s.data){    
        
         inputmeasurement.innerHTML+=`
         <div>
         <img  id="test7" src="https://localhost:7060/measurement/${dat.picture}" alt="">
         <label for="exampleInputPassword1">${dat.name}</label>
         <input type="number" name="${dat.name}" id="${dat.name}" required>
     </div>
         `
        
     }
      
    }
    
   let injectDesignId = async ()=>{
     getdesignid.innerHTML = `
     <input type="text" name="DesignId" value="${desid}" id="DesignId" placeholder = "${desid}" hidden>
     `
   }
    
   displaygetmeasurementbycustomer();