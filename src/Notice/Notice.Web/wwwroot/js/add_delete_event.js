function addEvent(id) {
    let pupils = document.getElementById("pupil");
    let pupil = document.createElement("h4");
    pupil.id = id
    let choose_pupil = document.getElementById("choose_pupil");
    pupil.innerHTML = choose_pupil.options[choose_pupil.selectedIndex].text + '<button class="dropbtn" onclick="deleteEvent(' + id + ')" > <img src="../krestik.png" class="bell"></button ></h4 >';
    pupils.prepend(pupil);
}

function addPupil(selectEl) {
    var value = (selectEl) ? selectEl.options[selectEl.selectedIndex].value : null;

    if (value != "Select pupil") {
        let pupils = document.getElementById("pupils");

        let pupil = document.createElement("h4");
        pupil.id = value;

        let choose_pupil = document.getElementById("pupilList");
        pupil.innerHTML = choose_pupil.options[choose_pupil.selectedIndex].text +
            '<button class="dropbtn" onclick="deleteEvent(' + value +
            ')" > <img src="../krestik.png" class="bell"></button ></h4 >';
        pupils.prepend(pupil);
    }
}

function addTeacher(selectEl) {

    var value = (selectEl) ? selectEl.options[selectEl.selectedIndex].value : null;

    if (value != "Select teacher") {
        let pupils = document.getElementById("teachers");

        let pupil = document.createElement("h4");
        pupil.id = value;

        let choose_pupil = document.getElementById("teacherList");
        pupil.innerHTML = selectEl.options[choose_pupil.selectedIndex].text +
            '<button class="dropbtn" onclick="deleteEvent(' + value +
            ')" > <img src="../krestik.png" class="bell"></button ></h4 >';
        pupils.prepend(pupil);

        alert(value);
    }
}

function deleteEvent(id) {
    let pupil = document.getElementById(id);
    pupil.remove();
}