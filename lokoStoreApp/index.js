//Require modules needed
const express = require("express");
const path = require("path");
const { MongoClient, ObjectId } = require("mongodb");

//Set up mongoDB config stuffs
const dbUrl = "mongodb://127.0.0.1:27017";
const client = new MongoClient(dbUrl);

//Setting up express app and port number
const app = express();
const port = process.env.PORT || 8887;

//Set up static file paths
app.use(express.static(path.join(__dirname, "public")));

//Set up template engine
app.set("views", path.join(__dirname, "viewsTemplate"));
app.set("view engine", "pug");

//Post data is retrived in the form of a query strings
//e.g. weight=0path=/&name=Home. converting to JSON for easier use

app.use(express.urlencoded({ extended: true}));
app.use(express.json());

/*
var links = [
    {
        name: "Home",
        path: "/"
    },
    {
        name: "About",
        path: "/about"
    }
];*/

//Page routes
app.get("/", async(request, response) => {
    //response.status(200).send("Testing lokoStoreApp Page 50");
    links = await getLinks();
    response.render("index", {title: "Home", menu:links});
});

app.get("/about", async(request, response) => {
    links = await getLinks();
    response.render("about", { title: "About", menu:links});
});

app.get("/admin/menu", async(request, response) => {
    links = await getLinks();
    response.render("menu-list", { title: "menu-list", menu: links})
});

app.get("/admin/menu/add", async(request, response) => {
    links = await getLinks();
    response.render("menu-add", {title: "menu-add", menu: links});
});

//Form processing paths
// For a POST form, the data is retrived through the body

app.post("/admin/menu/add/submit", async(request, response) => {
    let newLink = {
        weight: request.body.weight,
        path: request.body.path,
        name: request.body.name
    }
await addLink(newLink);
response.redirect("/admin/menu");
});

app.get("/admin/menu/edit", async (request, response) => {
    links = await getLinks();

    editLinkData = await getSingleLink(request.query.linkId);
  
    response.render("menu-edit", { title: "Edit menu link", menu: links, editLink: editLinkData });
  });

app.get("/admin/menu/delete", async (request, response) => {
    //for a GET form, the data is passed in request.query
    //request.query.<field_name>
    await deleteLink(request.query.linkId);
    response.redirect("/admin/menu");
  });

  app.post("/admin/menu/edit/submit", async (request, response) => {
    //get the id
    let IdFilter = request.body.linkId;
    
    //console.log(editLink._id);
  
    //get the weight/path/name values from the form and use for a document to update
    let link = {
      weight: request.body.weight,
      path: request.body.path,
      name: request.body.name
    };
  
    //run editLink()
    await editLink(IdFilter, link);
  
    response.redirect("/admin/menu");
  });

  

//Set up server listening
app.listen(port, () => {
    console.log(`Listening on https://localhost:${port}`);
});

//Mongo functions
//function to connect to mongoDB server and return the database "lokoStoreAppDB"
async function connection() {
    await client.connect();
    db = client.db("lokoStoreAppDB");
    return db;
}

//Function to select all document in menuLinks collection in lokoStoreAppDB
async function getLinks() {
    let db = await connection();
    let results = db.collection("menuLinks").find({});
    //console.log(result);
    let res = await results.toArray();

    return res;
}

//Function to take a new document and insert it in menuLinks collection

async function addLink(link) {
    db = await connection();
    await db.collection("menuLinks").insertOne(link);
    //console.log("Link added");
}

/* Function to delete one document by id. */
async function deleteLink(id) {
    db = await connection();
    const deleteIdFilter = { _id: new ObjectId(id) };
    const result = db.collection("menuLinks").deleteOne(deleteIdFilter);
    //if (result.deletedCount === 1)
      //console.log("delete successful");
  }

  /* Function to select a single document from menuLinks. */
async function getSingleLink(id) {
    db = await connection();
    const editIdFilter = { _id: new ObjectId(id) };
    const result = db.collection("menuLinks").findOne(editIdFilter);
    //console.log(result);
    return result;
  }

  /* Function to update a given link */
async function editLink(id, link) {

    db = await connection();

    const updateIdFilter = {_id: new ObjectId(id)};

    const updateDoc = { $set: {link}};

    result = await db.collection("menuLinks").updateOne(updateIdFilter, updateDoc);
    
    return result;
  
  }
