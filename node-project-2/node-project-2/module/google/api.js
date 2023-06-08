//const baseURL = "https://maps.googleapis.com/maps/api/staticmap?";
const baseURL = "https://www.google.com/maps/embed/v1/view?";

//Function to call the Google static maps API

async function googlestaticmaps(lat, long) {
  const reqURL = `${baseURL}key=${process.env.GOOGLE_CLIENT_ID}&center=${lat},${long}&zoom=12`;
  //const reqURL = `${baseURL}center=${lat},${long}&zoom=12&size=400x340&key=${process.env.GOOGLE_CLIENT_ID}`;

  let response = await fetch(
    reqURL,
    {
      method: "GET"
    }
  );

  return await response.url;
}

module.exports = {
  googlestaticmaps
}