import { useState, useEffect } from "react";
import '../styles/project.css'

export default function Project({titles}) {
  const [ projects, setProjects ] = useState([]);

  useEffect(() => {
    const getProject = async () => {
      let response = await fetch(
        "https://webprojectslukmon.ca/api/projects"
      );
      let data = await response.json();
      //console.log(data);
      setProjects(data);
    }
    getProject();

  }, [])


  return(
    <div id="project-content">
      <div id="project-heading">
      <h2 id="project_head">
        
        <a href="https://webprojectslukmon.ca/api/projects">Projects:</a> </h2>
        <p>Welcome to my portfolio, where I showcase some of my favorite projects I've worked on. As a web developer, I've had the privilege of working with clients from various industries and creating projects that align with their unique needs and goals. From branding and graphic design to web development and marketing campaigns, each project represents a unique challenge and opportunity for creativity. Browse through the list below to get a sense of my skills and expertise, and feel free to click on each project to learn more.</p>
        </div>
      <div id="projects">
        {projects.map((project) => (
          <div key={project.id} className="Iproject">
            <a id="title" href={project.url}>
              <h3>{project.title}</h3>
            </a>
            <div>{project.content}</div>
            <div>{project.created_at}</div>
          </div>
        ))}
      </div>
    </div>
  );
}