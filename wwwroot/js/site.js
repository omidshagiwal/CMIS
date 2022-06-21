function getDefaultOption() {
    var defaultOption = document.createElement("option");
    defaultOption.text = "...انتخاب نمودن...";
    defaultOption.disabled = true;
    defaultOption.setAttribute("selected", "true");
    defaultOption.setAttribute("value", "-1");
    return defaultOption;
}

function getNode(element) {
    const div = document.createElement('div');
    div.innerHTML = element.trim();
    return div.firstChild;
}

function imageUpload(srcElementId, tergetElementId) {
    var image = document.getElementById(srcElementId);
    var imageContainer = document.getElementById(tergetElementId);

    var fileReader = new FileReader();
    fileReader.readAsDataURL(image.files[0]);

    fileReader.onload = function () {
        imageContainer.src = this.result;
    }
}

async function getDistricts(provincesElementId,
    districtsElementId, schoolsElementId, yearsElementId, sectionsElementId = "") {
    if (schoolsElementId != "") {
        resetSchools(schoolsElementId);
    }
    if (yearsElementId != "") {
        resetYears(yearsElementId);
    }
    if (sectionsElementId != "") {
        resetSections(sectionsElementId);
    }

    const provinces = document.getElementById(provincesElementId);
    const selectedProvinceId = provinces.options[provinces.selectedIndex].value;

    const res = await fetch("/helpers/districts?provinceId=" + selectedProvinceId)
    const data = await res.json();

    const districts = document.getElementById(districtsElementId);
    districts.innerHTML = "";
    districts.appendChild(getDefaultOption());

    for (const district of data) {
        var option = document.createElement("option");
        option.text = district.text;
        option.value = district.value;
        districts.appendChild(option);
    }
}

async function getSchools(districtsElementId, schoolsElementId, yearsElementId, sectionsElementId="") {
    if (yearsElementId != "") {
        resetYears(yearsElementId);
    }
    if (sectionsElementId != "") {
        resetSections(sectionsElementId);
    }

    const districts = document.getElementById(districtsElementId);
    const selectedDistrictId = districts.options[districts.selectedIndex].value;

    const res = await fetch("/helpers/schools?districtId=" + selectedDistrictId)
    const data = await res.json();

    const schools = document.getElementById(schoolsElementId);
    schools.innerHTML = "";
    schools.appendChild(getDefaultOption());

    for (const school of data) {
        var option = document.createElement("option");
        option.text = school.text;
        option.value = school.value;

        schools.appendChild(option);
    }
}

function schoolSelected(yearsElementId) {
    resetYears(yearsElementId);
}

function resetSchools(schoolsElementId) {
    const schools = document.getElementById(schoolsElementId);
    schools.innerHTML = "";
    schools.appendChild(getDefaultOption());
}

var sections = null;
async function getSections(sectionsElementId) {
    if (sections != null)
        return;

    const res = await fetch("/helpers/sections")
    sections = await res.json();

    const sectionsSelect = document.getElementById(sectionsElementId);
    sectionsSelect.innerHTML = "";
    sectionsSelect.appendChild(getDefaultOption());

    for (const section of sections) {
        var option = document.createElement("option");
        option.text = section.text;
        option.value = section.value;
        sectionsSelect.appendChild(option);
    }
}

function resetSections(sectionsElementId) {
    const sectionsSelect = document.getElementById(sectionsElementId);
    sectionsSelect.innerHTML = "";
    sectionsSelect.appendChild(getDefaultOption());

    for (const section of sections) {
        var option = document.createElement("option");
        option.text = section.text;
        option.value = section.value;
        sectionsSelect.appendChild(option);
    }
}

var years = null;
async function getYears(yearsElementId) {
    if (years != null)
        return;

    const res = await fetch("/helpers/years")
    years = await res.json();

    const yearsSelect = document.getElementById(yearsElementId);
    yearsSelect.innerHTML = "";
    yearsSelect.appendChild(getDefaultOption());

    for (const year of years) {
        var option = document.createElement("option");
        option.text = year.text;
        option.value = year.value;
        yearsSelect.appendChild(option);
    }
}

function resetYears(yearsElementId) {
    const yearsSelect = document.getElementById(yearsElementId);
    yearsSelect.innerHTML = "";
    yearsSelect.appendChild(getDefaultOption());

    for (const year of years) {
        var option = document.createElement("option");
        option.text = year.text;
        option.value = year.value;
        yearsSelect.appendChild(option);
    }
}

function getLoader() {
    return getNode(`
        <div class="d-flex justify-content-center p-5">
            <div class="spinner-border text-primary" role="status"
            style="width: 7rem; height: 7rem;font-weight:bolder;"></div>
        </div>
    `);
}

function getOrderNumbersSelect(id, onChangeFnName) {
    return getNode(`
        <div class="form-group">
            <label for="${id}">نمبر ترتیب</label>
            <select id="${id}" class="form-control select-2" onchange="${onChangeFnName}();">
                <option selected disabled>...انتخاب نمودن...</option>
            </select>
        </div>
    `);
}

function removeOrderNumbersSelect(boxId) {
    document.getElementById(boxId).classList = "";
    document.getElementById(boxId).innerHTML = "";
}

function loadOrderNumbers(id) {
    const orderNumbersSelect = document.getElementById(id);
    orderNumbersSelect.innerHTML = "";
    orderNumbersSelect.appendChild(getDefaultOption());

    for (var a = 1; a <= 32; a++) {
        var option = document.createElement("option");
        option.text = a;
        option.value = a;
        orderNumbersSelect.appendChild(option);
    }
}