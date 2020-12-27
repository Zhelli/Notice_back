function proverka() {
    let proverka = true;
    let name = document.getElementById("name").value;
    if (name.trim() === "" || /^[a-zA-Z]*$/.test(name) === false) {
        document.getElementById("name").style.border = "2px solid red";
        proverka = false;
    }
    let patronymic = document.getElementById("patronymic").value;
    if (patronymic.trim() === "" || /^[a-zA-Z]*$/.test(patronymic) === false) {
        document.getElementById("patronymic").style.border = "2px solid red";
        proverka = false;
    }
    let surname = document.getElementById("surname").value;
    if (surname.trim() === "" || /^[a-zA-Z]*$/.test(surname) === false) {
        document.getElementById("surname").style.border = "2px solid red";
        proverka = false;
    }
    let phone = document.getElementById("phone").value;
    if (phone.trim() === "" || /^380[0-9]{9}$/i.test(phone) !== true) {
        document.getElementById("phone").style.border = "2px solid red";
        proverka = false;
    } 
    let mail = document.getElementById("email").value;
    if (mail.trim() === "" || /^[\w-\.]+@[\w-]+\.[a-z]{2,4}$/i.test(mail) !== true) {
        document.getElementById("email").style.border = "2px solid red";
        proverka = false;
    }
    if (proverka === false) {
        alert("Data no valid");
    } else {
        alert("Succesful");
    }
}
function proverka_class() {
    let classname = document.getElementById("classname").value;
    let proverka = true;
    if (classname.trim() === "") {
        document.getElementById("classname").style.border = "2px solid red";
        proverka = false;
    }
    let teacher = document.getElementById("teacher").value;
    if (teacher.trim() !== "") {
        document.getElementById("teacher").style.border = "2px solid red";
        proverka = false;
    }
    if (proverka === false) {
        alert("Data no valid");
    } else {
        alert("Succesful");
    }
}
function proverka_shedule() {
    let subject = document.getElementById("subject").value;
    let proverka = true;
    if (subject.trim() === "") {
        document.getElementById("subject").style.border = "2px solid red";
        proverka = false;
    }
    let classroom = document.getElementById("classroom").value;
    if (classroom.trim() === "") {
        document.getElementById("classroom").style.border = "2px solid red";
        proverka = false;
    }
    let classes = document.getElementById("class").value;
    if (classes.trim() === "") {
        document.getElementById("class").style.border = "2px solid red";
        proverka = false;
    }
    let teacher = document.getElementById("teacher").value;
    if (teacher.trim() === "") {
        document.getElementById("teacher").style.border = "2px solid red";
        proverka = false;
    }
    if (proverka === false) {
        alert("Data no valid");
    } else {
        alert("Succesful");
    }
}
function proverka_event() {
    let name = document.getElementById("name_event").value;
    let proverka = true;
    if (name.trim() === "") {
        document.getElementById("name_event").style.border = "2px solid red";
        proverka = false;
    }
    let content = document.getElementById("event_content").value;
    if (content.trim() !== "") {
        document.getElementById("event_content").style.border = "2px solid red";
        proverka = false;
    }
    if (proverka === false) {
        alert("Data no valid");
    } else {
        alert("Succesful");
    }
}