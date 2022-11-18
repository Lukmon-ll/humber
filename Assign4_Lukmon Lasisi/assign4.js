//alert('This is it');

window.onload = regPageLoad;

function regPageLoad() 
{

    var FORM = document.forms.ixdForm;

    FORM.onsubmit = FORMsubmit;

    function FORMsubmit() 
    {

        var HEAD = document.getElementById("welcome");
        var REGBODY = document.getElementById("form");
        var HIDDENmessage = document.getElementById("result");
        var Delivery = document.getElementById("caption_deliver");
        var pSelection = document.getElementById("caption_project");
        /*var firstnameValue = FORM.f_fName.value;
        var lastnameValue = FORM.f_lName.value;
        var HUMBERID = FORM.f_id.value;
        var HUMBERP = FORM.f_program.value;
        var proOPTION = FORM.f__deliver.value;
        var fullPROJECT = FORM.f__project.value;

        var output = firstnameValue + lastnameValue + "(" + HUMBERID + " in " + HUMBERP + ")" + " has been registered for the " + proOPTION + " option of the " + fullPROJECT + " project.";

        HIDDENmessage.innerHTML = output;*/


        //console.log(FIRSTNAME);
        //var FIRSTNAMEINPUT = document.getElementById("in_fName");
        
        
        //console.log(FIRSTNAME.value);
       //var FIRSTNAME = FORM.f_fName;
        //var FIRSTNAMEVALUE = FIRSTNAME.value;

        var fname = document.getElementById("in_fName");
        //console.log(fname.value);
        var lname = document.getElementById("in_lName");
        var humberid = document.getElementById("in_id");
        var programname = document.getElementById("in_program");

        var programnameInput = "";
        if (programname.value == "CS")
        {
            programnameInput = "Content Strategy";
        }else if (programname.value == "UX")
        {
            programnameInput = "User Experience Design";
        }else if (programname.value == "WD")
        {
            programnameInput = "Web Development";
        }
        //console.log(programnameInput);
        
        var optionname1 = document.getElementById("in_online");
        //console.log(optionname1.value); 

        var optionname2 = document.getElementById("in_person");
        //console.log(optionname2.value); 

        //var optionname = document.querySelector('[name = "f_deliver"]');
        //console.log(optionname.value);
        var proOption = "";
        if (optionname1.checked)
        {
            console.log(optionname1.value);
            proOption = "Online";
        }else if (optionname2.checked)
        {
            console.log(optionname2.value);
            proOption = "In-person";
        }
        //console.log(proOption);
        var projectname1 = document.getElementById("in_restaurant");
        var projectname2 = document.getElementById("in_humber");
        var projectname3 = document.getElementById("in_self");

        var fullProject = "";
        if (projectname1.checked)
        {

            fullProject = "LEGO Project";
        }else if (projectname2.checked)
        {
            fullProject = "Humber Current Project";
        }else if (projectname3.checked)
        {
            fullProject = "Self-determined Project";
        }
        var output = "";
        output = fname.value + " " + lname.value + " ( " + humberid.value + " in " + programnameInput + " ) " + " has been registered for the " + proOption + " option of the " + fullProject + " project.";
        HIDDENmessage.innerHTML = output;

        
        if (fname.value == "")
        {
           
            fname.style.backgroundColor = "red";
            fname.focus();
            return false;
        }

        if (lname.value == "")
        {
           
            lname.style.backgroundColor = "red";
            lname.focus();
            return false;
        }

        if (humberid.value == "")
        {
           
            humberid.style.backgroundColor = "red";
            humberid.focus();
            return false;
        }

        if (programname.value == "X")
        {
            programname.style.backgroundColor = "red";
            return false;
        }


        if (optionname1.checked == false && optionname2.checked == false)
        {
            Delivery.style.backgroundColor = "red";
            return false;
        }


        if (projectname1.checked == false && projectname2.checked == false && projectname3.checked == false)
        {
            pSelection.style.backgroundColor = "red";
            return false;
        }

        
    

        HEAD.style.display = "none";
        REGBODY.style.display = "none";

        HIDDENmessage.style.display = "block";


        return false;
    }
}


