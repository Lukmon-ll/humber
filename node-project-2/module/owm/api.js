//Set up base url
const baseURL = "https://api.openweathermap.org/data/2.5";

//var lat = 49.758123;
//var long = -92.653490;



//Function to call the open weather map API
async function openweathermap(lat, long) {
  const req1URL = `${baseURL}/weather?lat=${lat}&lon=${long}&appid=${process.env.OWM_CLIENT_ID}`;

  let response = await fetch(
    req1URL,
    {
      method: "GET",
      header: "application/json"
    }
    
  );

  return await response.json();
}

module.exports = {
  openweathermap
}