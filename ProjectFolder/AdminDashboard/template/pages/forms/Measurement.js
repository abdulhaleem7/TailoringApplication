var get = document.getElementById('ClothId'); 

async function getJSON () {
    const response = await fetch(`https://localhost:7060/api/Cloth/GetAll`);
    let d = response.json();
    console.log(d);
     return (d);

    }

   
async function displayCloths () {
   let s = await getJSON();
 for(var dat of s.data){
    console.log(dat);
     get.innerHTML+=`
     <option value=${dat.id}> ${dat.name}</option>
     `
 }
}

displayCloths();
const MeasurementValue = document.querySelector('#MeasurementValue');

MeasurementValue.addEventListener('submit',(e)=>{
    e.preventDefault();
    let sendForm = new FormData(MeasurementValue);
    fetch(`https://localhost:7060/api/Measurement/Create`,
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

