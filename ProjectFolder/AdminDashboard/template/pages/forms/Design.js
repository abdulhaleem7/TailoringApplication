
console.log("seen")
var get = document.getElementById('ClothId'); 

async function getJSON () {
    console.log("seen1")
    const response = await fetch('https://localhost:7060/api/Cloth/GetAll');
    let d = response.json();
    console.log(d);
     return (d);

    }

   
let displayCloths = async ()  => {
   let s = await getJSON();
   console.log(s);
   console.log("1");
   console.log(s.data);

 for(var dat of s.data){
     console.log(dat)
     get.innerHTML+=`
     <option value=${dat.id}> ${dat.name}</option>
     `
 }
}

displayCloths();
console.log("3777")
const designform = document.querySelector('#designform');
const ColourForm= document.querySelector('#ColourForm')

designform.addEventListener('submit',(e)=>{
    e.preventDefault();
    let sendForm = new FormData(designform);
    fetch(`https://localhost:7060/api/Design/Create`,
    {
        
        method: "POST",
        body: sendForm
    })
    .then(res => res.json())
    .then(data =>{
        if(data.status === false){
            alert(data.message)
        }
        else if(data.status == true){
         alert(data.message)
         document.location.reload(true);
        }
              
    })
});


ColourForm.addEventListener('submit',(e)=>{
    e.preventDefault();
    let sendForm = new FormData(ColourForm);
    fetch(`https://localhost:7060/api/Colour/Create`,
    {
        
        method: "POST",
        body: sendForm
    })
    .then(res => res.json())
    .then(data =>{
        if(data.status === false){
            alert(data.message)
        }
        else if(data.status == true){
         alert(data.message)
         document.location.reload(true);
        }
              
    })
});
