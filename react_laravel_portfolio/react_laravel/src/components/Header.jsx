import { Link } from "react-router-dom";
import Nav from "./Nav";
import '../styles/header.css'

export default function Header() {
  return(

    <header>
      <h1 className="header-main">
        <Link to="/">Lukmon's Portfolio Website</Link></h1>
        <Nav />
    </header>
  );
}