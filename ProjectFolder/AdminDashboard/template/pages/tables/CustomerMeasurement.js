var measure = document.getElementById('measure');
var id = window.location.href.split("=")[1];

async function measurement() {
    const getOrders = await fetch(`https://localhost:7060/GetMeasurementOrderByCustomerId/${id}`)
    let s = getOrders.json();
    console.log(s);
    return s;
}


let measurementDetails = async ()=>{
    var get = await measurement();
    
        console.log(get);
        measure.innerHTML =`
          <tr>
            <div>
            <th>Suit Lenght</th>
            <td>${get.data.suitLenght}</td>
            <th>Suit Waist</th>
            <td>${get.data.suitWaist}</td>
          </div>
          </tr>
          <tr>
            <th>Suit Chest</th>
            <td>${get.data.suitChest}</td>
            <th>Suit Shoulder</th>
            <td>${get.data.suitShoulder}</td>
          </tr>
          <tr>
            <th>Suit Sleeve</th>  
            <td>${get.data.suitSleeve}</td>
            <th>TrouserLenght</th>
            <td>${get.data.trouserLenght}</td>
          </tr>
          <tr>
            <th>TrouserWaist</th>  
            <td>${get.data.trouserWaist}</td>
            <th>TrouserTight</th>  
            <td>${get.data.trouserTight}</td>
          </tr>
          <tr>
            <th>TrouserKnee</th>  
            <td>${get.data.trouserKnee}</td>
            <th>ShirtLenght</th>
            <td>${get.data.shirtLenght}</td>
          </tr>

          <tr>
            <th>ShirtWaist</th>  
            <td>${get.data.shirtWaist}</td>
            <th>ShirtShoulder</th>  
            <td>${get.data.shirtShoulder}</td>
          </tr>

          <tr>
            <th>WaistCoatLenght</th>  
            <td>${get.data.waistCoatLenght}</td>                        
            <th>ShirtSleeve</th>
            <td>${get.data.shirtSleeve}</td>
          </tr>
          <tr>
            <th>WaistCoatWaist</th>
            <td>${get.data.waistCoatWaist}</td>
            <th>NativeLenght</th>  
            <td>${get.data.nativeLenght}</td>
          </tr>
          <tr>
            <th>NativeWaist</th>
            <td>${get.data.nativeWaist}</td>                         
            <th>NativeShoulder</th>  
            <td>${get.data.nativeShoulder}</td>
          </tr>
          <tr>
            <th>NativeSleeve</th>
            <td>${get.data.nativeSleeve}</td>
            <th>NativeTrouserLenght</th>  
            <td>${get.data.nativeTrouserLenght}</td>
          </tr>
          <tr>
            <th>NativeTrouserTight</th>
            <td>${get.data.nativeTrouserTight}</td>
            <th>NativeTrouserKnee</th>  
            <td>${get.data.nativeTrouserKnee}</td>
          </tr>
          <tr>
            <th>KneekerLenght</th>
            <td>${get.data.kneekerLenght}</td>
            <th>KneekerWaist</th>  
            <td>${get.data.kneekerWaist}</td>
          </tr>
          <tr>
            <th>KneekerTight</th>
            <td>${get.data.kneekerTight}</td>
            <th>AgbadaLenght</th>  
            <td>${get.data.agbadaLenght}</td>
          </tr>
          <tr>
            <th>NativeCap</th>
            <td>${get.data.nativeCap}</td>
          </tr>`
    
}


measurementDetails();