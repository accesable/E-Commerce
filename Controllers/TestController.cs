using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace E_Commerces.Controllers;

public class TestController : Controller{
    public string Index(){
        return "This is A Controller for Testing";
    }
    // This route accept http://localhost:5226/test/welcome/2?name=nhutanh
    // And http://localhost:5226/test/welcome?id=1&name=nhutanh
    // http://localhost:5226/test/welcome?name=nhutanh
    public string Welcome(string name ,int ID = -1){
        return HtmlEncoder.Default.Encode($"Welcome to the Test Controller Platform Your ID {ID} and name : {name}");   
    }
}