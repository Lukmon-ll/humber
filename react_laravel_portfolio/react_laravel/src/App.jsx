import { BrowserRouter, Routes, Route} from "react-router-dom";

import Header from "./components/Header";
import Footer from "./components/Footer";
import './App.css'

//import the routes pages
import Home from "./routes/Home";
import About from "./routes/About";
import Contacts from "./routes/Contacts";
import Education from "./routes/Education";
function App() {
  
  return (
    <div className="App">
      <BrowserRouter>
      <Header />
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/about" element={<About />} />
        <Route path="/contacts" element={<Contacts />} />
        <Route path="/education" element={<Education />} />
      </Routes>
      <Footer />
      </BrowserRouter>
    </div>
  )
}

export default App
