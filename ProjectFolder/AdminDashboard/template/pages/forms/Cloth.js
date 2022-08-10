
console.log("seen")
var get = document.getElementById('CategoryId'); 

async function getJSON () {
    console.log("seen1")
    const response = await fetch('https://localhost:7060/api/Category/GetAll');
    let d = response.json();
    console.log(d);
     return (d);

    }

   
let displayCloth = async ()  => {
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

displayCloth();
console.log("3777")
const myform = document.querySelector('#myformvalue');

myform.addEventListener('submit',(e)=>{
    e.preventDefault();
    let sendForm = new FormData(myform);
    fetch(`https://localhost:7060/api/Cloth/Create`,
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
