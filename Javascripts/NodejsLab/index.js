//Import the required modules
const express = require("express");
const path = require("path");
const { MongoClient } = require("mongodb");

//Set up an express app and port number
const app = express();
const port = process.env.PORT || 8888;

//set up mongodb config stuff
//const dbUrl = "mongodb://127.0.0.1:27017";

const dbUrl = "mongodb+srv://lokolassStore:sF9iALCqdvAuqJkO@cluster0.vt0tvyi.mongodb.net/lokolassStoreDB?retryWrites=true&w=majority";
const client = new MongoClient(dbUrl);


//Set up template engine
app.set("views", path.join(__dirname, "views"));
app.set("view engine", "pug");

//Set up static files
app.use(express.static(path.join(__dirname, "public")));

//Page routes
app.get("/", async(request, response) => {
//response.status(200).send("Testing lokolass store the second time and the fouth time and the sixth time the 7th time");
//response.render("layout", {title: "layout template"});
category = await getIC();
links = await getLinks();
response.render("index", {title: "Home", menu: links, category: category});

});

app.get("/about", async(request, response) => {

  links = await getLinks();
  response.render("about", {title: "About", menu: links})
});

app.get("/contact", async(request, response) => {

  links = await getLinks();
  response.render("contact", { title: "Contact page", menu: links});
});

//Set up server listening
app.listen(port, () => {
  console.log(`Listening on http://localhost:${port}`);
});


//Mongo functions
//function to connect to mongoDB server and return the database "lokolassStoreDB"
async function connection() {
  await client.connect();
  db = client.db("lokolassStoreDB");
  return db;
}

//Function to select all document in menulinks collection in lokolassStoreDB
async function getLinks() {
  let db = await connection();
  let results = db.collection("menulinks").find({});
  //console.log(result);
  let res = await results.toArray();

  return res;
}

//Function to get item categories(all documents in iCtegory collection in lokolassStoreDB) from the mongo DB
async function getIC() {
  let db = await connection();
  let result = db.collection("iCategory").find({});
  let res = await result.toArray();
  return res;
}