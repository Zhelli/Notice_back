function addEvent(id) {
    let pupils = document.getElementById("pupil");
    let pupil = document.createElement("h4");
    pupil.id = id
    let choose_pupil = document.getElementById("choose_pupil");
    pupil.innerHTML = choose_pupil.options[choose_pupil.selectedIndex].text + '<button class="dropbtn" onclick="deleteEvent(' + id + ')" > <img src="../krestik.png" class="bell"></button ></h4 >';
    pupils.prepend(pupil);
}

function deleteEvent(id) {
    let pupil = document.getElementById(id);
    pupil.remove();
}