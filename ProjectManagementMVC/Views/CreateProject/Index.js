function PcrForm() {
    this.baseUrl;

    this.initialize = function (_baseUrl) {
        this.baseUrl = _baseUrl;
    }

    this.unHideSubMenu = function (id) {
        let x = document.getElementById(id);
        if (x.className.indexOf("w3-hide") == -1) {
            x.className += " w3-hide";
            //x.previousElementSibling.className += " w3-theme-d1";
        } else {
            x.className = x.className.replace("w3-hide", "");
            //x.previousElementSibling.className = x.previousElementSibling.className.replace(" w3-theme-d1", "");
        }
    }

    this._getDivisionList = function () { return '<select id="secA_Divison" name="secA_Division" class="w3-select"><option value="Dhaka" selected>Dhaka</option><option value="Chattogram">Chattogram</option><option value="Rajshahi">Rajshahi</option><option value="Khulna">Khulna</option><option value="Sylhet">Sylhet</option><option value="Barishal">Barishal</option><option value="Rangpur">Rangpur</option><option value="Mymensingh">Mymensingh</option></select>'; }

    this._getDistrictList = function (division) { return '<select class="w3-select"><option value="dhaka">Dhaka</option><option value="chattogram">Chattogram</option><option value="rajshahi">Rajshahi</option><option value="khulna">Khulna</option><option value="sylhet">Sylhet</option></select>'; }

    this._getUpazilaList = function (division, upazila) { return '<select class="w3-select"><option value="savarp">Savar</option><option value="raozan">Raozan</option><option value="paba">Paba</option><option value="dumuria">Dumuria</option><option value="beanibazar">Beanibazar</option></select>'; }

    this.secA_LocationTable_Add = function () {
        let table = document.getElementById("secA_LocationTable");
        let row = table.insertRow(-1);
        let tmpCell = row.insertCell(0);
        tmpCell.innerHTML = "0";
        tmpCell = row.insertCell(1);
        tmpCell.innerHTML = this._getDivisionList();
        tmpCell = row.insertCell(2);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(3);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        this.tableReserial("secA_LocationTable", 2);
    }

    this.secA_EtimatedCostTable_Add = function () {
        let table = document.getElementById("secA_EtimatedCostTable");
        let row = table.insertRow(-1);
        let tmpCell = row.insertCell(0);
        tmpCell.innerHTML = '<select class="w3-select"><option>Original</option><option>1st Revised</option><option>2nd Revised</option><option>3rd Revised</option><option>4th Revised</option><option>5th Revised</option><option>1st No Cost Extension</option><option>2nd No Cost Extension</option><option>3rd No Cost Extension</option><option>4th No Cost Extension</option><option>5th No Cost Extension</option><option>Intercomponent Adjustment</option></select>';
        tmpCell = row.insertCell(1);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(2);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(3);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(4);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(5);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(6);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="date">';
        tmpCell = row.insertCell(7);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
    }

    this.secA_LoanStatus_ForeignTable_Add = function () {
        let table = document.getElementById("secA_LoanStatus_ForeignTable");
        let row = table.insertRow(-1);
        let tmpCell = row.insertCell(0);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(1);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(2);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(3);
        tmpCell.innerHTML = '<select class="w3-select"><option>Loan</option><option>Grant</option><option>Supplier’s credit</option></select>';
        tmpCell = row.insertCell(4);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="date">';
        tmpCell = row.insertCell(5);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="date">';
        tmpCell = row.insertCell(6);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="date">';
        tmpCell = row.insertCell(7);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="date">';
    }

    this.secA_LoanStatus_GobTable_Add = function () {
        let table = document.getElementById("secA_LoanStatus_GobTable");
        let row = table.insertRow(-1);
        let tmpCell = row.insertCell(0);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(1);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(2);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(3);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
    }

    this.secA_LoanStatus_SelfTable_Add = function () {
        let table = document.getElementById("secA_LoanStatus_SelfTable");
        let row = table.insertRow(-1);
        let tmpCell = row.insertCell(0);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(1);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(2);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(3);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
    }

    this.secA_UtilizationTable_Add = function () {
        let table = document.getElementById("secA_UtilizationTable");
        let row = table.insertRow(-1);
        let tmpCell = row.insertCell(0);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(1);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(2);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(3);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(4);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(5);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(6);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
    }

    this.secA_RpaTable_Add = function () {
        let table = document.getElementById("secA_RpaTable");
        let row = table.insertRow(-1);
        let tmpCell = row.insertCell(0);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(1);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(2);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(3);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(4);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(5);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(6);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
    }

    this.secB_ImplPeriodTable_Add = function () {
        let table = document.getElementById("secB_ImplPeriodTable");
        let row = table.insertRow(-1);
        let tmpCell = row.insertCell(0);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(1);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(2);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(3);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(4);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
    }

    this.secB_PrjCostTable_Add = function () {
        let table = document.getElementById("secB_PrjCostTable");
        let row = table.insertRow(-1);
        let tmpCell = row.insertCell(0);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(1);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(2);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(3);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(4);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(5);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
    }

    this.secB_PdInfoTable_Add = function () {
        let table = document.getElementById("secB_PdInfoTable");
        let row = table.insertRow(-1);
        let tmpCell = row.insertCell(0);
        tmpCell.innerHTML = '<textarea class="w3-input w3-border w3-round-large"></textarea>';
        tmpCell = row.insertCell(1);
        tmpCell.innerHTML = '<select class="w3-select"><option>Yes</option><option>No</option></select>';
        tmpCell = row.insertCell(2);
        tmpCell.innerHTML = '<select class="w3-select"><option>Yes</option><option>No</option></select>';
        tmpCell = row.insertCell(3);
        tmpCell.innerHTML = '<select class="w3-select"><option>Yes</option><option>No</option></select>';
        tmpCell = row.insertCell(4);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="date">';
        tmpCell = row.insertCell(5);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="date">';
        tmpCell = row.insertCell(6);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
    }

    this.secB_PiuTable_Add = function () {
        let table = document.getElementById("secB_PiuTable");
        let row = table.insertRow(table.rows.length - 1);
        let tmpCell = row.insertCell(0);
        tmpCell.innerHTML = "0";
        tmpCell = row.insertCell(1);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(2);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(3);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        this.tableReserial("secB_PiuTable", 3, true);
        //this.tableSum("secB_PiuTable",3,[1,2,3]);
    }

    this.secB_PerReqAftComTable_Add = function () {
        let table = document.getElementById("secB_PerReqAftComTable");
        let row = table.insertRow(table.rows.length - 1);
        let tmpCell = row.insertCell(0);
        tmpCell.innerHTML = "0";
        tmpCell = row.insertCell(1);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(2);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(3);
        tmpCell.innerHTML = '<select class="w3-select"><option>Yes</option><option>No</option></select>';
        tmpCell = row.insertCell(4);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        this.tableReserial("secB_PerReqAftComTable", 4, true);
        //this.tableSum("secB_PiuTable",3,[1,2,3]);
    }

    this.secB_TrainingTable_Add = function () {
        let table = document.getElementById("secB_TrainingTable");
        let row = table.insertRow(table.rows.length - 3);
        let tmpCell = row.insertCell(0);
        // tmpCell.innerHTML = "0";
        // tmpCell = row.insertCell(1);
        tmpCell.innerHTML = '<select class="w3-select"><option>Local Training</option><option>Foreign Training</option></select>';
        tmpCell = row.insertCell(1);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(2);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(3);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(4);
        tmpCell.innerHTML = '<textarea class="w3-input w3-border w3-round-large"></textarea>';
        tmpCell = row.insertCell(5);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(6);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(7);
        tmpCell.innerHTML = '<textarea class="w3-input w3-border w3-round-large"></textarea>';
        //this.tableReserial("secB_TrainingTable",5,true);
        //this.tableSum("secB_PiuTable",3,[1,2,3]);
    }

    this.secB_CompWiseProgressTable_Add = function () {
        let table = document.getElementById("secB_CompWiseProgressTable");
        let row = table.insertRow(table.rows.length - 3);
        let tmpCell = row.insertCell(0);
        tmpCell.innerHTML = '<select class="w3-select"><option>Revenue</option><option>Capital</option></select>';
        tmpCell = row.insertCell(1);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(2);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(3);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(4);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(5);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(6);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(7);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(8);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(9);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(10);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(11);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(12);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(13);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        //this.tableSum("secB_PiuTable",3,[1,2,3]);
    }

    this.secB_ProcureTransportTable_Add = function () {
        let table = document.getElementById("secB_ProcureTransportTable");
        let row = table.insertRow(-1);
        let tmpCell = row.insertCell(0);
        tmpCell.innerHTML = '<select class="w3-select"><option>Car</option><option>Jeep</option><option>Microbus</option><option>Minibus</option><option>Bus</option><option>Pick-up</option><option>Truck</option><option>Motor-Cycle</option><option>By-cycle</option><option>Speed Boat</option><option>Launch</option><option>Other</option></select>';
        tmpCell = row.insertCell(1);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(2);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text"><input class="w3-input w3-border w3-round-large" type="date">';
        tmpCell = row.insertCell(3);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text"><input class="w3-input w3-border w3-round-large" type="date">';
        tmpCell = row.insertCell(4);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text"><input class="w3-input w3-border w3-round-large" type="date">';
        tmpCell = row.insertCell(5);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text"><input class="w3-input w3-border w3-round-large" type="date">';
        tmpCell = row.insertCell(6);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text"><input class="w3-input w3-border w3-round-large" type="date">';
        tmpCell = row.insertCell(7);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
    }

    this.secB_PrjConsultantTable_Add = function () {
        let table = document.getElementById("secB_PrjConsultantTable");
        let row = table.insertRow(-1);
        let tmpCell = row.insertCell(0);
        tmpCell.innerHTML = '<select class="w3-select"><option>Local</option><option>Foreign</option></select>';
        tmpCell = row.insertCell(1);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(2);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(3);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(4);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(5);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(6);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(7);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
    }

    this.secB_ToolsEquipTable_Add = function () {
        let table = document.getElementById("secB_ToolsEquipTable");
        let row = table.insertRow(-1);
        let tmpCell = row.insertCell(0);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(1);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(2);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text"><input class="w3-input w3-border w3-round-large" type="date">';
        tmpCell = row.insertCell(3);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text"><input class="w3-input w3-border w3-round-large" type="date">';
        tmpCell = row.insertCell(4);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text"><input class="w3-input w3-border w3-round-large" type="date">';
        tmpCell = row.insertCell(5);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(6);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
    }

    this.secC_FinProvPhyTgtTable_Add = function () {
        let table = document.getElementById("secC_FinProvPhyTgtTable");
        let row = table.insertRow(-1);
        let tmpCell = row.insertCell(0);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(1);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(2);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(3);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(4);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(5);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(6);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(7);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(8);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(9);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(10);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(11);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(12);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
    }

    this.secC_RevAdpTable_Add = function () {
        let table = document.getElementById("secC_RevAdpTable");
        let row = table.insertRow(-1);
        let tmpCell = row.insertCell(0);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(1);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(2);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(3);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(4);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(5);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(6);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(7);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(8);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(9);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(10);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(11);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(12);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(13);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(14);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
    }

    this.secD_PrjAchievementTable_Add = function () {
        let table = document.getElementById("secD_PrjAchievementTable");
        let row = table.insertRow(-1);
        let tmpCell = row.insertCell(0);
        tmpCell.innerHTML = '0';
        tmpCell = row.insertCell(1);
        tmpCell.innerHTML = '<textarea class="w3-input w3-border w3-round-large"></textarea>';
        tmpCell = row.insertCell(2);
        tmpCell.innerHTML = '<textarea class="w3-input w3-border w3-round-large"></textarea>';
        tmpCell = row.insertCell(3);
        tmpCell.innerHTML = '<textarea class="w3-input w3-border w3-round-large"></textarea>';
        this.tableReserial("secD_PrjAchievementTable", 2);
    }

    this.secE_AnnOutTable_Add = function () {
        let table = document.getElementById("secE_AnnOutTable");
        let row = table.insertRow(-1);
        let tmpCell = row.insertCell(0);
        tmpCell.innerHTML = '0';
        tmpCell = row.insertCell(1);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(2);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(3);
        tmpCell.innerHTML = '<textarea class="w3-input w3-border w3-round-large"></textarea>';
        tmpCell = row.insertCell(4);
        tmpCell.innerHTML = '<textarea class="w3-input w3-border w3-round-large"></textarea>';
        this.tableReserial("secE_AnnOutTable", 2);
    }

    this.secE_CostBenifitTable_Add = function () {
        let table = document.getElementById("secE_CostBenifitTable");
        let row = table.insertRow(-1);
        let tmpCell = row.insertCell(0);
        tmpCell.innerHTML = '<select class="w3-select"><option>Benefit cost ratio of the project</option><option>Internal Rate of Return</option></select>';
        tmpCell = row.insertCell(1);
        tmpCell.innerHTML = '<select class="w3-select"><option>Financial</option><option>Economic</option></select>';
        tmpCell = row.insertCell(2);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(3);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
    }

    this.secF_MonitorTable_Add = function () {
        let table = document.getElementById("secF_MonitorTable");
        let row = table.insertRow(-1);
        let tmpCell = row.insertCell(0);
        tmpCell.innerHTML = '<select class="w3-select"><option>IMED</option><option>Ministry/Agency</option><option>Others: (Please specify)</option></select>';
        tmpCell = row.insertCell(1);
        tmpCell.innerHTML = '<textarea class="w3-input w3-border w3-round-large"></textarea>';
        tmpCell = row.insertCell(2);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="date">';
        tmpCell = row.insertCell(3);
        tmpCell.innerHTML = '<textarea class="w3-input w3-border w3-round-large"></textarea>';
        tmpCell = row.insertCell(4);
        tmpCell.innerHTML = '<textarea class="w3-input w3-border w3-round-large"></textarea>';
    }

    this.secF_IntAuditTable_Add = function () {
        let table = document.getElementById("secF_IntAuditTable");
        let row = table.insertRow(table.rows.length - 1);
        let tmpCell = row.insertCell(0);
        tmpCell.innerHTML = '0';
        tmpCell = row.insertCell(1);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="date"> To <input class="w3-input w3-border w3-round-large" type="date">';
        tmpCell = row.insertCell(2);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="date">';
        tmpCell = row.insertCell(3);
        tmpCell.innerHTML = '<textarea class="w3-input w3-border w3-round-large"></textarea>';
        tmpCell = row.insertCell(4);
        tmpCell.innerHTML = '<textarea class="w3-input w3-border w3-round-large"></textarea>';
        this.tableReserial("secF_IntAuditTable", 3, true);
    }

    this.secF_ExtAuditTable_Add = function () {
        let table = document.getElementById("secF_ExtAuditTable");
        let row = table.insertRow(table.rows.length - 1);
        let tmpCell = row.insertCell(0);
        tmpCell.innerHTML = '0';
        tmpCell = row.insertCell(1);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="date"> To <input class="w3-input w3-border w3-round-large" type="date">';
        tmpCell = row.insertCell(2);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="date">';
        tmpCell = row.insertCell(3);
        tmpCell.innerHTML = '<textarea class="w3-input w3-border w3-round-large"></textarea>';
        tmpCell = row.insertCell(4);
        tmpCell.innerHTML = '<textarea class="w3-input w3-border w3-round-large"></textarea>';
        this.tableReserial("secF_ExtAuditTable", 3, true);
    }

    this.tableReserial = function (tblName, startRow, hasTotal = false) {
        let rows = document.getElementById(tblName).getElementsByTagName("tr");
        let cnt = 0;
        let len = rows.length;
        if (hasTotal) len -= 1;
        for (let i = startRow; i < len; i++) {
            rows[i].getElementsByTagName("td")[0].innerHTML = ++cnt;
        }
    }

    this.removeTableLastRow = function (tblName, fixedTopRowNum, fixedBottomRowNum = 0) {
        let rows = document.getElementById(tblName).getElementsByTagName("tr");
        if (rows.length > (fixedTopRowNum + fixedBottomRowNum)) {
            rows[rows.length - fixedBottomRowNum - 1].remove();
        }
    }

    // this.tableSum = function(tblName,startRow,colNums){
    //     let rows = document.getElementById(tblName).getElementsByTagName("tr");
    //     let columns;
    //     let cnt = 0;
    //     let total = Array.from({ colNums.length }, () => 0);
    //     for(let i=startRow;i<rows.length;i++){
    //         //rows[i].getElementsByTagName("td")[0].innerHTML = ++cnt;
    //         columns = rows[i].getElementsByTagName("td");
    //         for(let j=0;j<colNums.length;j++){
    //             total[j] += parseFloat(columns[j].innerHTML);
    //         }
    //     }
    //     console.log(total);
    // }

    this.loadSign = function (divName) {
        let img = new Image();
        let width = 300;
        let height = 80;
        const canvas = document.createElement('canvas');
        let file = document.getElementById(divName + "Input").files;
        document.getElementById(divName).innerHTML = "";
        document.getElementById(divName).appendChild(canvas);
        let ctx = canvas.getContext("2d");
        canvas.width = width;
        canvas.height = height;
        let reader = new FileReader();
        reader.onload = (function (e) {
            console.log('loaded')
            // document.getElementById('grid').style.backgroundImage = "url("+e.target.result+")";

            img.src = e.target.result
            //img.src = reader.result;
        });
        reader.readAsDataURL(file[0]);

        img.onload = (function () {
            ctx.drawImage(img, 0, 0, width, height);
        });
    }

    this.annexure1a_GoodsTable_Add = function () {
        const table = document.getElementById("annexure1a_GoodsTable");

        // First row (Plan)
        const row1 = table.insertRow(-1);
        row1.innerHTML = `
                <td rowspan="3"><textarea class="w3-input w3-border w3-round-large"></textarea></td>
                <td rowspan="3"><textarea class="w3-input w3-border w3-round-large"></textarea></td>
                <td><input class="w3-input w3-border w3-round-large" type="text" value="Plan"></td>
                <td><input class="w3-input w3-border w3-round-large" type="text"></td>
                <td><input class="w3-input w3-border w3-round-large" type="text"></td>
                <td><input class="w3-input w3-border w3-round-large" type="text"></td>
                <td rowspan="3"><textarea class="w3-input w3-border w3-round-large"></textarea></td>
                <td><input class="w3-input w3-border w3-round-large" type="date"></td>
                <td><input class="w3-input w3-border w3-round-large" type="date"></td>
                <td><input class="w3-input w3-border w3-round-large" type="date"></td>
                <td rowspan="3"><input class="w3-input w3-border w3-round-large" type="text"><br><input class="w3-input w3-border w3-round-large" type="date"></td>
                <td rowspan="3"><textarea class="w3-input w3-border w3-round-large"></textarea></td>
                <td rowspan="3"><input class="w3-input w3-border w3-round-large" type="date"></td>
                <td rowspan="3"><input class="w3-input w3-border w3-round-large" type="date"></td>
            `;

        // Second row (Actual)
        const row2 = table.insertRow(-1);
        row2.innerHTML = `
                <td><input class="w3-input w3-border w3-round-large" type="text" value="Actual"></td>
                <td><input class="w3-input w3-border w3-round-large" type="text"></td>
                <td><input class="w3-input w3-border w3-round-large" type="text"></td>
                <td><input class="w3-input w3-border w3-round-large" type="date"></td>
                <td><input class="w3-input w3-border w3-round-large" type="date"></td>
                <td><input class="w3-input w3-border w3-round-large" type="date"></td>
                <td><input class="w3-input w3-border w3-round-large" type="date"></td>
            `;

        // Third row (Deviation)
        const row3 = table.insertRow(-1);
        row3.innerHTML = `
                <td><input class="w3-input w3-border w3-round-large" type="text" value="Deviation"></td>
                <td><input class="w3-input w3-border w3-round-large" type="text"></td>
                <td><input class="w3-input w3-border w3-round-large" type="text"></td>
                <td><input class="w3-input w3-border w3-round-large" type="date"></td>
                <td><input class="w3-input w3-border w3-round-large" type="date"></td>
                <td><input class="w3-input w3-border w3-round-large" type="date"></td>
                <td><input class="w3-input w3-border w3-round-large" type="date"></td>
            `;
    };

    this.annexure1b_WorksTable_Add = function () {
        const table = document.getElementById("annexure1b_WorksTable");

        // First row (Plan)
        const row1 = table.insertRow(-1);
        row1.innerHTML = `
                <td rowspan="3"><textarea class="w3-input w3-border w3-round-large"></textarea></td>
                <td rowspan="3"><textarea class="w3-input w3-border w3-round-large"></textarea></td>
                <td><input class="w3-input w3-border w3-round-large" type="text" value="Plan"></td>
                <td><input class="w3-input w3-border w3-round-large" type="text"></td>
                <td><input class="w3-input w3-border w3-round-large" type="text"></td>
                <td><input class="w3-input w3-border w3-round-large" type="text"></td>
                <td rowspan="3"><textarea class="w3-input w3-border w3-round-large"></textarea></td>
                <td><input class="w3-input w3-border w3-round-large" type="date"></td>
                <td><input class="w3-input w3-border w3-round-large" type="date"></td>
                <td><input class="w3-input w3-border w3-round-large" type="date"></td>
                <td rowspan="3"><input class="w3-input w3-border w3-round-large" type="text"><br><input class="w3-input w3-border w3-round-large" type="date"></td>
                <td rowspan="3"><textarea class="w3-input w3-border w3-round-large"></textarea></td>
                <td rowspan="3"><input class="w3-input w3-border w3-round-large" type="date"></td>
                <td rowspan="3"><input class="w3-input w3-border w3-round-large" type="date"></td>
            `;

        // Second row (Actual)
        const row2 = table.insertRow(-1);
        row2.innerHTML = `
                <td><input class="w3-input w3-border w3-round-large" type="text" value="Actual"></td>
                <td><input class="w3-input w3-border w3-round-large" type="text"></td>
                <td><input class="w3-input w3-border w3-round-large" type="text"></td>
                <td><input class="w3-input w3-border w3-round-large" type="date"></td>
                <td><input class="w3-input w3-border w3-round-large" type="date"></td>
                <td><input class="w3-input w3-border w3-round-large" type="date"></td>
                <td><input class="w3-input w3-border w3-round-large" type="date"></td>
            `;

        // Third row (Deviation)
        const row3 = table.insertRow(-1);
        row3.innerHTML = `
                <td><input class="w3-input w3-border w3-round-large" type="text" value="Deviation"></td>
                <td><input class="w3-input w3-border w3-round-large" type="text"></td>
                <td><input class="w3-input w3-border w3-round-large" type="text"></td>
                <td><input class="w3-input w3-border w3-round-large" type="date"></td>
                <td><input class="w3-input w3-border w3-round-large" type="date"></td>
                <td><input class="w3-input w3-border w3-round-large" type="date"></td>
                <td><input class="w3-input w3-border w3-round-large" type="date"></td>
            `;
    };

    this.annexure1c_ServicesTable_Add = function () {
        const table = document.getElementById("annexure1c_ServicesTable");

        // First row (Plan)
        const row1 = table.insertRow(-1);
        row1.innerHTML = `
                <td rowspan="3"><textarea class="w3-input w3-border w3-round-large"></textarea></td>
                <td rowspan="3"><textarea class="w3-input w3-border w3-round-large"></textarea></td>
                <td><input class="w3-input w3-border w3-round-large" type="text" value="Plan"></td>
                <td><input class="w3-input w3-border w3-round-large" type="text"></td>
                <td><input class="w3-input w3-border w3-round-large" type="text"></td>
                <td><input class="w3-input w3-border w3-round-large" type="text"></td>
                <td rowspan="3"><textarea class="w3-input w3-border w3-round-large"></textarea></td>
                <td><input class="w3-input w3-border w3-round-large" type="date"></td>
                <td><input class="w3-input w3-border w3-round-large" type="date"></td>
                <td><input class="w3-input w3-border w3-round-large" type="date"></td>
                <td rowspan="3"><input class="w3-input w3-border w3-round-large" type="text"><br><input class="w3-input w3-border w3-round-large" type="date"></td>
                <td rowspan="3"><textarea class="w3-input w3-border w3-round-large"></textarea></td>
                <td rowspan="3"><input class="w3-input w3-border w3-round-large" type="date"></td>
                <td rowspan="3"><input class="w3-input w3-border w3-round-large" type="date"></td>
            `;

        // Second row (Actual)
        const row2 = table.insertRow(-1);
        row2.innerHTML = `
                <td><input class="w3-input w3-border w3-round-large" type="text" value="Actual"></td>
                <td><input class="w3-input w3-border w3-round-large" type="text"></td>
                <td><input class="w3-input w3-border w3-round-large" type="text"></td>
                <td><input class="w3-input w3-border w3-round-large" type="date"></td>
                <td><input class="w3-input w3-border w3-round-large" type="date"></td>
                <td><input class="w3-input w3-border w3-round-large" type="date"></td>
                <td><input class="w3-input w3-border w3-round-large" type="date"></td>
            `;

        // Third row (Deviation)
        const row3 = table.insertRow(-1);
        row3.innerHTML = `
                <td><input class="w3-input w3-border w3-round-large" type="text" value="Deviation"></td>
                <td><input class="w3-input w3-border w3-round-large" type="text"></td>
                <td><input class="w3-input w3-border w3-round-large" type="text"></td>
                <td><input class="w3-input w3-border w3-round-large" type="date"></td>
                <td><input class="w3-input w3-border w3-round-large" type="date"></td>
                <td><input class="w3-input w3-border w3-round-large" type="date"></td>
                <td><input class="w3-input w3-border w3-round-large" type="date"></td>
            `;
    };

    this.saveProjectInternal = function (url, successMessage, status) {

        var payload = {
            Name: $("#secA_ProjectName").val(),
            AdministrativeMinistryDivision: $("#secA_MinistryDivision").val(),
            ExecutingAgency: $("#secA_Agency").val(),
            PlanningCommissionSectorDivision: $("#secA_PlanningSector").val(),
            Type: $("#secA_ProjectType").val(),
            OverallObjective: $("#secA_OverallObjective").val(),
            SpecificObjectives: $("#secA_SpecificObjectives").val(),
            Background: $("#secA_ProjectBackground").val(),
            MajorActivities: $("#secA_MajorActivities").val(),
            ReasonsForRevision: $("#secA_RevisionReason").val(),
            ReasonsForNoCostTimeExtension: $("#secA_NoCostRevisionReason").val(),
            Status: status
        };

        console.log("Frontendssss: ");
        console.log(payload);

        // Set dates dynamically based on signatures
        if (url === "/ForwardToED" && $("#pdSignInput")[0].files[0])
            $("#_36DatePD").val(new Date().toISOString().split("T")[0]);
        if (url === "/ForwardToSecretary" && $("#ahSignInput")[0].files[0])
            $("#_36DateAH").val(new Date().toISOString().split("T")[0]);
        if (url === "/MarkAsComplete" && $("#secSignInput")[0].files[0])
            $("#_36DateSec").val(new Date().toISOString().split("T")[0]);

        $.ajax({
            type: "POST",
            url: url,
            data: JSON.stringify(payload),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                console.log(successMessage + ":", response);
                const projectId = response.projectId || $("#projectId").val(); // Assume projectId input if available
                saveAdditionalData(projectId);
                alert(successMessage + " Project ID: " + projectId);
                if (url !== "/SaveAsDraft") location.reload(); // Reload except for draft
            },
            error: function (error) {
                console.error("Error:", error.responseText);
                alert("Error: " + error.responseText);
            }
        });
    };

    this.saveAsDraft = function () {
        this.saveProjectInternal("/SaveAsDraft", "Draft saved", "DraftED");
    };

    this.forwardToED = function () {
        this.saveProjectInternal("/ForwardToED", "Forwarded to ED", "ForwardedToED");
    };

    this.forwardToSecretary = function () {
        this.saveProjectInternal("/ForwardToSecretary", "Forwarded to Secretary", "ForwardedToSecretary");
    };

    this.sendBackToPD = function () {
        this.saveProjectInternal("/SendBackToPD", "Sent back to PD", "SentBackToPD");
    };

    this.markAsComplete = function () {
        this.saveProjectInternal("/MarkAsComplete", "Marked as Complete", "Completed");
    };

    this.sendBackToED = function () {
        this.saveProjectInternal("/SendBackToED", "Sent back to ED", "SentBackToED");
    };
}


// Instantiate pcrForm
let pcrForm = null;
if (typeof pcrForm === 'undefined' || pcrForm === null) {
    pcrForm = new PcrForm();
    pcrForm.initialize("/");
}

// Standalone saveAdditionalData and saveXxxData functions
function saveAdditionalData(projectId) {
    saveLocationData(projectId);
    saveEstimatedCostData(projectId);
    saveLoanGrantForeignFinancingData(projectId);
    saveLoanGrantGOBData(projectId);
    saveLoanGrantSelfFinanceEquityData(projectId);
    saveUtilizationOfProjectAidData(projectId);
    saveReimbursableProjectAidData(projectId);
    saveImplementationPeriodData(projectId);
    saveCostOfTheProjectData(projectId);
    saveInfoProjectDirectorData(projectId);
    savePersonnelOfPIUData(projectId);
    savePersonnelRequiredAfterCompletionData(projectId);
    savePersonnelData(projectId);
    saveTrainingForeignLocalData(projectId);
    saveComponentWiseProgressData(projectId);
    save_17_18TotalData(projectId);
    saveProcurementOfTransportData(projectId);
    saveProjectConsultantData(projectId);
    saveInfrastructureErectionInstalationData(projectId);
    saveInfoOnPackageData(projectId);
    saveOriginalAndRevisedProvisionTargetData(projectId);
    saveRevisedADPAllocationAndProgressData(projectId);
    saveObjectiveAchievementData(projectId);
    saveAnnualOutputData(projectId);
    saveCostBenefitData(projectId);
    saveMonitoringData(projectId);
    saveInternalAuditData(projectId);
    saveExternalAuditData(projectId);
    saveAuditingData(projectId);
    saveProcurementGoodsData(projectId);
    saveProcurementWorksData(projectId);
    saveProcurementServicesData(projectId);
    savePostProjectRemarkData(projectId);
}



function saveLocationData(projectId) {

    var _06LocationOfTheProjects = [];

    const locationTable = document.getElementById("secA_LocationTable");
    const locationRows = locationTable.querySelectorAll("tr:not(:first-child):not(:nth-child(2))");

    locationRows.forEach(row => {
        const location = {
            ProjectId: projectId,
            Division: row.cells[1].querySelector("select").value,
            District: row.cells[2].querySelector("input").value,
            CityCorpMunicipalityUpazila: row.cells[3].querySelector("input").value
        };
        _06LocationOfTheProjects.push(location);
    });

    console.log(_06LocationOfTheProjects);

    $.ajax({
        type: "POST",
        url: "/SaveLocationOfTheProject",
        data: JSON.stringify(_06LocationOfTheProjects),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            console.log("Location data saved:", response);
            // alert("Location data saved successfully!");
        },
        error: function (error) {
            console.error("Error saving location data:", error.responseText);
            alert("Error saving location data: " + error.responseText);
        }
    });

}

function saveEstimatedCostData(projectId) {

    var _07EstimatedCostPeriodApprovals = [];

    const costTable = document.getElementById("secA_EtimatedCostTable");
    const costRows = costTable.querySelectorAll("tr:not(:first-child):not(:nth-child(2)):not(:nth-child(3)):not(:nth-child(4))");

    costRows.forEach(row => {
        const cost = {
            ProjectId: projectId,
            Subject: row.cells[0].querySelector("select").value,
            Total: row.cells[1].querySelector("input").value,
            GOB: row.cells[2].querySelector("input").value,
            PA: row.cells[3].querySelector("input").value,
            SelfFinance: row.cells[4].querySelector("input").value,
            ImplementationPeriod: row.cells[5].querySelector("input").value,
            DateOfApproval: row.cells[6].querySelector("input").value,
            ApprovedBy: row.cells[7].querySelector("input").value
        };
        _07EstimatedCostPeriodApprovals.push(cost);
    });

    console.log(_07EstimatedCostPeriodApprovals);

    $.ajax({
        type: "POST",
        url: "/SaveEstimatedCostPeriodApproval",
        data: JSON.stringify(_07EstimatedCostPeriodApprovals),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            console.log("Estimated cost data saved:", response);
            // alert("Estimated cost data saved successfully!");
        },
        error: function (error) {
            console.error("Error saving Estimated cost data:", error.responseText);
            alert("Error saving Estimated cost data: " + error.responseText);
        }
    });
}

function saveLoanGrantForeignFinancingData(projectId) {

    var _12_1aStatusOfLoanGrantForeignFinancings = [];

    const loanGrantTable = document.getElementById("secA_LoanStatus_ForeignTable");
    const loanGrantRows = loanGrantTable.querySelectorAll("tr:not(:first-child):not(:nth-child(2)):not(:nth-child(3)):not(:nth-child(4))");

    loanGrantRows.forEach(row => {
        const loanGrant = {
            ProjectId: projectId,
            Source: row.cells[0].querySelector("input").value,
            CurrencyAsPerAgreement: row.cells[1].querySelector("input").value,
            AmountInUSD: row.cells[2].querySelector("input").value,
            Nature: row.cells[3].querySelector("select").value,
            DateOfAgreement: row.cells[4].querySelector("input").value,
            DateOfEffectiveness: row.cells[5].querySelector("input").value,
            OriginalDateOfClosing: row.cells[6].querySelector("input").value,
            RevisedDateOfClosing: row.cells[7].querySelector("input").value
        };
        _12_1aStatusOfLoanGrantForeignFinancings.push(loanGrant);
    });

    console.log(_12_1aStatusOfLoanGrantForeignFinancings);

    $.ajax({
        type: "POST",
        url: "/SaveLoanGrantForeignFinancing",
        data: JSON.stringify(_12_1aStatusOfLoanGrantForeignFinancings),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            console.log("Loan grant foreign financing data saved:", response);
            // alert("Loan grant foreign financing data saved successfully!");
        },
        error: function (error) {
            console.error("Error saving loan grant foreign financing data:", error.responseText);
            alert("Error saving loan grant foreign financing data: " + error.responseText);
        }
    });
}

function saveLoanGrantGOBData(projectId) {

    var _12_1bStatusOfLoanGrantGOBs = [];

    const loanGrantTable = document.getElementById("secA_LoanStatus_GobTable");
    const loanGrantRows = loanGrantTable.querySelectorAll("tr:not(:first-child):not(:nth-child(2)):not(:nth-child(3))");

    loanGrantRows.forEach(row => {
        const loanGrant = {
            ProjectId: projectId,
            TotalAmount: row.cells[0].querySelector("input").value,
            Loan: row.cells[1].querySelector("input").value,
            Grant: row.cells[2].querySelector("input").value,
            CashForeignExchange: row.cells[3].querySelector("input").value
        };
        _12_1bStatusOfLoanGrantGOBs.push(loanGrant);
    });

    console.log(_12_1bStatusOfLoanGrantGOBs);

    $.ajax({
        type: "POST",
        url: "/SaveLoanGrantGOB",
        data: JSON.stringify(_12_1bStatusOfLoanGrantGOBs),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            console.log("Loan grant GOB data saved:", response);
            // alert("Loan grant GOB data saved successfully!");
        },
        error: function (error) {
            console.error("Error saving loan grant GOB data:", error.responseText);
            alert("Error saving loan grant GOB data: " + error.responseText);
        }
    });
}

function saveLoanGrantSelfFinanceEquityData(projectId) {

    var _12_1cStatusOfLoanGrantSelfFinanceEquities = [];

    const loanGrantTable = document.getElementById("secA_LoanStatus_SelfTable");
    const loanGrantRows = loanGrantTable.querySelectorAll("tr:not(:first-child):not(:nth-child(2)):not(:nth-child(3))");

    loanGrantRows.forEach(row => {
        const loanGrant = {
            ProjectId: projectId,
            TotalAmount: row.cells[0].querySelector("input").value,
            SelfFinance: row.cells[1].querySelector("input").value,
            Equity: row.cells[2].querySelector("input").value,
            CashForeignExchange: row.cells[3].querySelector("input").value
        };
        _12_1cStatusOfLoanGrantSelfFinanceEquities.push(loanGrant);
    });

    console.log(_12_1cStatusOfLoanGrantSelfFinanceEquities);

    $.ajax({
        type: "POST",
        url: "/SaveLoanGrantSelfFinanceEquity",
        data: JSON.stringify(_12_1cStatusOfLoanGrantSelfFinanceEquities),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            console.log("Loan grant Self-Finance/Equity data saved:", response);
            // alert("Loan grant Self-Finance/Equity data saved successfully!");
        },
        error: function (error) {
            console.error("Error saving loan grant Self-Finance/Equity data:", error.responseText);
            alert("Error saving loan grant Self-Finance/Equity data: " + error.responseText);
        }
    });
}

function saveUtilizationOfProjectAidData(projectId) {

    var _12_2UtilizationOfProjectAids = [];

    const table = document.getElementById("secA_UtilizationTable");
    const tableRows = table.querySelectorAll("tr:not(:first-child):not(:nth-child(2)):not(:nth-child(3)):not(:nth-child(4))");

    tableRows.forEach(row => {
        const data = {
            ProjectId: projectId,
            Source: row.cells[0].querySelector("input").value,
            TotalAmountInUSD: row.cells[1].querySelector("input").value,
            TotalAmountInLocalCurrency: row.cells[2].querySelector("input").value,
            ActualExpenditureInUSD: row.cells[3].querySelector("input").value,
            ActualExpenditureInLocalCurrency: row.cells[4].querySelector("input").value,
            UnutilizedAmountInUSD: row.cells[5].querySelector("input").value,
            UnutilizedAmountInLocalCurrency: row.cells[6].querySelector("input").value
        };
        _12_2UtilizationOfProjectAids.push(data);
    });

    console.log(_12_2UtilizationOfProjectAids);

    $.ajax({
        type: "POST",
        url: "/SaveUtilizationOfProjectAid",
        data: JSON.stringify(_12_2UtilizationOfProjectAids),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            console.log("_12_2UtilizationOfProjectAid data saved:", response);
            // alert("_12_2UtilizationOfProjectAid saved successfully!");
        },
        error: function (error) {
            console.error("Error saving _12_2UtilizationOfProjectAid data:", error.responseText);
            alert("Error saving _12_2UtilizationOfProjectAid data: " + error.responseText);
        }
    });
}

function saveReimbursableProjectAidData(projectId) {

    var _12_3ReimbursableProjectAids = [];

    const table = document.getElementById("secA_RpaTable");
    const tableRows = table.querySelectorAll("tr:not(:first-child):not(:nth-child(2)):not(:nth-child(3)):not(:nth-child(4))");

    tableRows.forEach(row => {
        const data = {
            ProjectId: projectId,
            Source: row.cells[0].querySelector("input").value,
            RPAAmountAsPerPD: row.cells[1].querySelector("input").value,
            RPAAmountAsPerAgreement: row.cells[2].querySelector("input").value,
            AmountSpent: row.cells[3].querySelector("input").value,
            AmountClaimed: row.cells[4].querySelector("input").value,
            AmountReimbursed: row.cells[5].querySelector("input").value,
            Remarks: row.cells[6].querySelector("input").value
        };
        _12_3ReimbursableProjectAids.push(data);
    });

    console.log(_12_3ReimbursableProjectAids);

    $.ajax({
        type: "POST",
        url: "/SaveReimbursableProjectAid",
        data: JSON.stringify(_12_3ReimbursableProjectAids),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            console.log("_12_3ReimbursableProjectAid data saved:", response);
            // alert("_12_3ReimbursableProjectAid saved successfully!");
        },
        error: function (error) {
            console.error("Error saving _12_3ReimbursableProjectAid data:", error.responseText);
            alert("Error saving _12_3ReimbursableProjectAid data: " + error.responseText);
        }
    });
}

function saveImplementationPeriodData(projectId) {

    var _13ImplementationPeriods = [];

    const table = document.getElementById("secB_ImplPeriodTable");
    const tableRows = table.querySelectorAll("tr:not(:first-child):not(:nth-child(2)):not(:nth-child(3)):not(:nth-child(4))");

    tableRows.forEach(row => {
        const data = {
            ProjectId: projectId,
            Original: row.cells[0].querySelector("input").value,
            LatestRevised: row.cells[1].querySelector("input").value,
            ActualImplementation: row.cells[2].querySelector("input").value,
            TimeOverRun: row.cells[3].querySelector("input").value,
            Remarks: row.cells[4].querySelector("input").value,
        };
        _13ImplementationPeriods.push(data);
    });

    console.log(_13ImplementationPeriods);

    $.ajax({
        type: "POST",
        url: "/SaveImplementationPeriod",
        data: JSON.stringify(_13ImplementationPeriods),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            console.log("_13ImplementationPeriod data saved:", response);
            // alert("_13ImplementationPeriod saved successfully!");
        },
        error: function (error) {
            console.error("Error saving _13ImplementationPeriod data:", error.responseText);
            alert("Error saving _13ImplementationPeriod data: " + error.responseText);
        }
    });
}

function saveCostOfTheProjectData(projectId) {

    var _14CostOfTheProjects = [];

    const table = document.getElementById("secB_PrjCostTable");
    const tableRows = table.querySelectorAll("tr:not(:first-child):not(:nth-child(2)):not(:nth-child(3)):not(:nth-child(4))");

    tableRows.forEach(row => {
        const data = {
            ProjectId: projectId,
            Description: row.cells[0].querySelector("input").value,
            OriginalEstimatedCost: row.cells[1].querySelector("input").value,
            LatestRevisedEstimatedCost: row.cells[2].querySelector("input").value,
            ActualExpenditure: row.cells[3].querySelector("input").value,
            CostOverRun: row.cells[4].querySelector("input").value,
            Remarks: row.cells[5].querySelector("input").value
        };
        _14CostOfTheProjects.push(data);
    });

    console.log(_14CostOfTheProjects);

    $.ajax({
        type: "POST",
        url: "/SaveCostOfTheProject",
        data: JSON.stringify(_14CostOfTheProjects),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            console.log("_14CostOfTheProject data saved:", response);
            // alert("_14CostOfTheProject saved successfully!");
        },
        error: function (error) {
            console.error("Error saving _14CostOfTheProject data:", error.responseText);
            alert("Error saving _14CostOfTheProject data: " + error.responseText);
        }
    });
}

function saveInfoProjectDirectorData(projectId) {

    var _15InfoProjectDirectors = [];

    const table = document.getElementById("secB_PdInfoTable");
    const tableRows = table.querySelectorAll("tr:not(:first-child):not(:nth-child(2)):not(:nth-child(3)):not(:nth-child(4))");

    tableRows.forEach(row => {
        const data = {
            ProjectId: projectId,
            NameAndDetails: row.cells[0].querySelector("textarea").value,
            FullTime: row.cells[1].querySelector("select").value,
            PartTime: row.cells[2].querySelector("select").value,
            ResponsibleForMoreThanOneProject: row.cells[3].querySelector("select").value,
            Joining: row.cells[4].querySelector("input").value,
            Transfer: row.cells[5].querySelector("input").value,
            Remarks: row.cells[6].querySelector("input").value
        };
        _15InfoProjectDirectors.push(data);
    });

    console.log(_15InfoProjectDirectors);

    $.ajax({
        type: "POST",
        url: "/SaveInfoProjectDirector",
        data: JSON.stringify(_15InfoProjectDirectors),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            console.log("_15InfoProjectDirector data saved:", response);
            // alert("_15InfoProjectDirector saved successfully!");
        },
        error: function (error) {
            console.error("Error saving _15InfoProjectDirector data:", error.responseText);
            alert("Error saving _15InfoProjectDirector data: " + error.responseText);
        }
    });
}

function savePersonnelOfPIUData(projectId) {

    var _16_1PersonnelOfPIUs = [];

    const table = document.getElementById("secB_PiuTable");
    const tableRows = table.querySelectorAll("tr:not(:first-child):not(:nth-child(2)):not(:nth-child(3)):not(:last-child)");

    tableRows.forEach(row => {
        const data = {
            ProjectId: projectId,
            NameOfPost: row.cells[1].querySelector("input").value,
            ApprovedStrength: row.cells[2].querySelector("input").value,
            EmployedDuringImplementation: row.cells[3].querySelector("input").value,
        };
        _16_1PersonnelOfPIUs.push(data);
    });

    console.log(_16_1PersonnelOfPIUs);

    $.ajax({
        type: "POST",
        url: "/SavePersonnelOfPIU",
        data: JSON.stringify(_16_1PersonnelOfPIUs),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            console.log("_16_1PersonnelOfPIUs data saved:", response);
            // alert("_16_1PersonnelOfPIUs saved successfully!");
        },
        error: function (error) {
            console.error("Error saving _16_1PersonnelOfPIUs data:", error.responseText);
            alert("Error saving _16_1PersonnelOfPIUs data: " + error.responseText);
        }
    });
}

function savePersonnelRequiredAfterCompletionData(projectId) {

    var _16_2PersonnelRequiredAfterCompletions = [];

    const table = document.getElementById("secB_PerReqAftComTable");
    const tableRows = table.querySelectorAll("tr:not(:first-child):not(:nth-child(2)):not(:nth-child(3)):not(:nth-child(4)):not(:last-child)");

    tableRows.forEach(row => {
        const data = {
            ProjectId: projectId,
            NameOfPost: row.cells[1].querySelector("input").value,
            Number: row.cells[2].querySelector("input").value,
            Recruited: row.cells[3].querySelector("select").value,
            ReasonForNotRecruited: row.cells[4].querySelector("input").value,
        };
        _16_2PersonnelRequiredAfterCompletions.push(data);
    });

    console.log(_16_2PersonnelRequiredAfterCompletions);

    $.ajax({
        type: "POST",
        url: "/SavePersonnelRequiredAfterCompletion",
        data: JSON.stringify(_16_2PersonnelRequiredAfterCompletions),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            console.log("_16_2PersonnelRequiredAfterCompletions data saved:", response);
            // alert("_16_2PersonnelRequiredAfterCompletions saved successfully!");
        },
        error: function (error) {
            console.error("Error saving _16_2PersonnelRequiredAfterCompletions data:", error.responseText);
            alert("Error saving _16_2PersonnelRequiredAfterCompletions data: " + error.responseText);
        }
    });
}

function savePersonnelData(projectId) {

    const table1 = document.getElementById("secB_PiuTable");
    const table2 = document.getElementById("secB_PerReqAftComTable");
    const lastRow1 = table1.querySelector("tr:last-child");
    const lastRow2 = table2.querySelector("tr:last-child");

    const data = {
        ProjectId: projectId,
        TotalNameOfPostGrade: lastRow1.cells[1].querySelector("input").value,
        TotalApprovedStrength: lastRow1.cells[2].querySelector("input").value,
        TotalEmployedDuringImplementation: lastRow1.cells[3].querySelector("input").value,
        TotalNameOfPost: lastRow2.cells[1].querySelector("input").value,
        TotalNumber: lastRow2.cells[2].querySelector("input").value,
        TotalRecruited: lastRow2.cells[3].querySelector("input").value,
        TotalReasonForNotRecruited: lastRow2.cells[4].querySelector("input").value,
    }

    console.log(data);

    $.ajax({
        type: "POST",
        url: "/SavePersonnel",
        data: JSON.stringify(data),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            console.log("_16Personnel data saved:", response);
            // alert("_16Personnel saved successfully!");
        },
        error: function (error) {
            console.error("Error saving _16Personnel data:", error.responseText);
            alert("Error saving _16Personnel data: " + error.responseText);
        }
    });
}

function saveTrainingForeignLocalData(projectId) {

    var _17TrainingForeignLocals = [];

    const table = document.getElementById("secB_TrainingTable");
    const tableRows = table.querySelectorAll("tr:not(:first-child):not(:nth-child(2)):not(:nth-child(3)):not(:nth-child(4)):not(:nth-child(5)):not(:nth-last-child(1)):not(:nth-last-child(2)):not(:nth-last-child(3))");

    tableRows.forEach(row => {
        const data = {
            ProjectId: projectId,
            Category: row.cells[0].querySelector("select").value,
            SlNo: row.cells[1].querySelector("input").value,
            DWMAsInPD: row.cells[2].querySelector("input").value,
            BatchAsInPD: row.cells[3].querySelector("input").value,
            ParticipantAsInPD: row.cells[4].querySelector("textarea").value,
            DWMAchievement: row.cells[5].querySelector("input").value,
            BatchAchievement: row.cells[6].querySelector("input").value,
            ParticipantAchievement: row.cells[7].querySelector("textarea").value
        };
        _17TrainingForeignLocals.push(data);
    });

    console.log(_17TrainingForeignLocals);

    $.ajax({
        type: "POST",
        url: "/SaveTrainingForeignLocal",
        data: JSON.stringify(_17TrainingForeignLocals),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            console.log("_17TrainingForeignLocal data saved:", response);
            // alert("_17TrainingForeignLocal saved successfully!");
        },
        error: function (error) {
            console.error("Error saving _17TrainingForeignLocal data:", error.responseText);
            alert("Error saving _17TrainingForeignLocal data: " + error.responseText);
        }
    });
}

function saveComponentWiseProgressData(projectId) {

    var _18ComponentWiseProgresses = [];

    const table = document.getElementById("secB_CompWiseProgressTable");
    const tableRows = table.querySelectorAll("tr:not(:first-child):not(:nth-child(2)):not(:nth-child(3)):not(:nth-child(4)):not(:nth-last-child(1)):not(:nth-last-child(2)):not(:nth-last-child(3))");

    tableRows.forEach(row => {
        const data = {
            ProjectId: projectId,
            Category: row.cells[0].querySelector("select").value,
            NameOfComponent: row.cells[1].querySelector("input").value,
            Unit: row.cells[2].querySelector("input").value,
            Quantity: row.cells[3].querySelector("input").value,
            EstimatedTotal: row.cells[4].querySelector("input").value,
            EstimatedGOB: row.cells[5].querySelector("input").value,
            EstimatedPA: row.cells[6].querySelector("input").value,
            EstimatedSelfFinance: row.cells[7].querySelector("input").value,
            EstimatedOthers: row.cells[8].querySelector("input").value,
            ActualTotal: row.cells[9].querySelector("input").value,
            ActualGOB: row.cells[10].querySelector("input").value,
            ActualPA: row.cells[11].querySelector("input").value,
            ActualSelfFinance: row.cells[12].querySelector("input").value,
            ActualOthers: row.cells[13].querySelector("input").value
        };
        _18ComponentWiseProgresses.push(data);
    });

    console.log(_18ComponentWiseProgresses);

    $.ajax({
        type: "POST",
        url: "/SaveComponentWiseProgress",
        data: JSON.stringify(_18ComponentWiseProgresses),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            console.log("_18ComponentWiseProgress data saved:", response);
            // alert("_18ComponentWiseProgress saved successfully!");
        },
        error: function (error) {
            console.error("Error saving _18ComponentWiseProgress data:", error.responseText);
            alert("Error saving _18ComponentWiseProgress data: " + error.responseText);
        }
    });
}

function save_17_18TotalData(projectId) {

    var payload = {
        ProjectId: projectId,
        SubTotalLocal_DWMAsInPD: $("#subTotalLocal_DWMAsInPD").val(),
        SubTotalLocal_BatchAsInPD: $("#subTotalLocal_BatchAsInPD").val(),
        SubTotalLocal_ParticipantAsInPD: $("#subTotalLocal_ParticipantAsInPD").val(),
        SubTotalLocal_DWMAchievement: $("#subTotalLocal_DWMAchievement").val(),
        SubTotalLocal_BatchAchievement: $("#subTotalLocal_BatchAchievement").val(),
        SubTotalLocal_ParticipantAchievement: $("#subTotalLocal_ParticipantAchievement").val(),
        SubTotalForeign_DWMAsInPD: $("#subTotalForeign_DWMAsInPD").val(),
        SubTotalForeign_BatchAsInPD: $("#subTotalForeign_BatchAsInPD").val(),
        SubTotalForeign_ParticipantAsInPD: $("#subTotalForeign_ParticipantAsInPD").val(),
        SubTotalForeign_DWMAchievement: $("#subTotalForeign_DWMAchievement").val(),
        SubTotalForeign_BatchAchievement: $("#subTotalForeign_BatchAchievement").val(),
        SubTotalForeign_ParticipantAchievement: $("#subTotalForeign_ParticipantAchievement").val(),
        TotalLocalForeign_DWMAsInPD: $("#totalLocalForeign_DWMAsInPD").val(),
        TotalLocalForeign_BatchAsInPD: $("#totalLocalForeign_BatchAsInPD").val(),
        TotalLocalForeign_ParticipantAsInPD: $("#totalLocalForeign_ParticipantAsInPD").val(),
        TotalLocalForeign_DWMAchievement: $("#totalLocalForeign_DWMAchievement").val(),
        TotalLocalForeign_BatchAchievement: $("#totalLocalForeign_BatchAchievement").val(),
        TotalLocalForeign_ParticipantAchievement: $("#totalLocalForeign_ParticipantAchievement").val(),
        SubTotalRevenue_EstimatedTotal: $("#subTotalRevenue_EstimatedTotal").val(),
        SubTotalRevenue_EstimatedGOB: $("#subTotalRevenue_EstimatedGOB").val(),
        SubTotalRevenue_EstimatedPA: $("#subTotalRevenue_EstimatedPA").val(),
        SubTotalRevenue_EstimatedSelfFinance: $("#subTotalRevenue_EstimatedSelfFinance").val(),
        SubTotalRevenue_EstimatedOthers: $("#subTotalRevenue_EstimatedOthers").val(),
        SubTotalRevenue_ActualTotal: $("#subTotalRevenue_ActualTotal").val(),
        SubTotalRevenue_ActualGOB: $("#subTotalRevenue_ActualGOB").val(),
        SubTotalRevenue_ActualPA: $("#subTotalRevenue_ActualPA").val(),
        SubTotalRevenue_ActualSelfFinance: $("#subTotalRevenue_ActualSelfFinance").val(),
        SubTotalRevenue_ActualOthers: $("#subTotalRevenue_ActualOthers").val(),
        SubTotalCapital_EstimatedTotal: $("#subTotalCapital_EstimatedTotal").val(),
        SubTotalCapital_EstimatedGOB: $("#subTotalCapital_EstimatedGOB").val(),
        SubTotalCapital_EstimatedPA: $("#subTotalCapital_EstimatedPA").val(),
        SubTotalCapital_EstimatedSelfFinance: $("#subTotalCapital_EstimatedSelfFinance").val(),
        SubTotalCapital_EstimatedOthers: $("#subTotalCapital_EstimatedOthers").val(),
        SubTotalCapital_ActualTotal: $("#subTotalCapital_ActualTotal").val(),
        SubTotalCapital_ActualGOB: $("#subTotalCapital_ActualGOB").val(),
        SubTotalCapital_ActualPA: $("#subTotalCapital_ActualPA").val(),
        SubTotalCapital_ActualSelfFinance: $("#subTotalCapital_ActualSelfFinance").val(),
        SubTotalCapital_ActualOthers: $("#subTotalCapital_ActualOthers").val(),
        TotalRevenueCapital_EstimatedTotal: $("#totalRevenueCapital_EstimatedTotal").val(),
        TotalRevenueCapital_EstimatedGOB: $("#totalRevenueCapital_EstimatedGOB").val(),
        TotalRevenueCapital_EstimatedPA: $("#totalRevenueCapital_EstimatedPA").val(),
        TotalRevenueCapital_EstimatedSelfFinance: $("#totalRevenueCapital_EstimatedSelfFinance").val(),
        TotalRevenueCapital_EstimatedOthers: $("#totalRevenueCapital_EstimatedOthers").val(),
        TotalRevenueCapital_ActualTotal: $("#totalRevenueCapital_ActualTotal").val(),
        TotalRevenueCapital_ActualGOB: $("#totalRevenueCapital_ActualGOB").val(),
        TotalRevenueCapital_ActualPA: $("#totalRevenueCapital_ActualPA").val(),
        TotalRevenueCapital_ActualSelfFinance: $("#totalRevenueCapital_ActualSelfFinance").val(),
        TotalRevenueCapital_ActualOthers: $("#totalRevenueCapital_ActualOthers").val()
    };

    console.log(payload);

    $.ajax({
        type: "POST",
        url: "/Save_17_18Total",
        data: JSON.stringify(payload),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            console.log("_17_18Totals data saved:", response);
            // alert("_17_18Totals saved successfully!");
        },
        error: function (error) {
            console.error("Error saving _17_18Totals data:", error.responseText);
            alert("Error saving _17_18Totals data: " + error.responseText);
        }
    });
}

function saveProcurementOfTransportData(projectId) {

    var _19ProcurementOfTransports = [];

    const table = document.getElementById("secB_ProcureTransportTable");
    const tableRows = table.querySelectorAll("tr:not(:first-child):not(:nth-child(2)):not(:nth-child(3))");

    tableRows.forEach(row => {
        const data = {
            ProjectId: projectId,
            TypeOfTransport: row.cells[0].querySelector("select").value,
            NumberAsPerProjectDocument: row.cells[1].querySelector("input").value,
            NumberProcured: row.cells[2].querySelectorAll("input")[0].value,
            NumberProcuredDate: row.cells[2].querySelectorAll("input")[1].value,
            TransferredToTransferPool: row.cells[3].querySelectorAll("input")[0].value,
            TransferredToTransferPoolDate: row.cells[3].querySelectorAll("input")[1].value,
            TransferredToOM: row.cells[4].querySelectorAll("input")[0].value,
            TransferredToOMDate: row.cells[4].querySelectorAll("input")[1].value,
            CondemnedDamaged: row.cells[5].querySelectorAll("input")[0].value,
            CondemnedDamagedDate: row.cells[5].querySelectorAll("input")[1].value,
            ReturnedToFollowingProject: row.cells[6].querySelectorAll("input")[0].value,
            ReturnedToFollowingProjectDate: row.cells[6].querySelectorAll("input")[1].value,
            Remarks: row.cells[7].querySelector("input").value
        };
        _19ProcurementOfTransports.push(data);
    });

    console.log(_19ProcurementOfTransports);

    $.ajax({
        type: "POST",
        url: "/SaveProcurementOfTransport",
        data: JSON.stringify(_19ProcurementOfTransports),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            console.log("_19ProcurementOfTransport data saved:", response);
            // alert("_19ProcurementOfTransport saved successfully!");
        },
        error: function (error) {
            console.error("Error saving _19ProcurementOfTransport data:", error.responseText);
            alert("Error saving _19ProcurementOfTransport data: " + error.responseText);
        }
    });
}

function saveProjectConsultantData(projectId) {

    var _20ProjectConsultants = [];

    const table = document.getElementById("secB_PrjConsultantTable");
    const tableRows = table.querySelectorAll("tr:not(:first-child):not(:nth-child(2)):not(:nth-child(3)):not(:nth-child(4))");

    tableRows.forEach(row => {
        const data = {
            ProjectId: projectId,
            Category: row.cells[0].querySelector("select").value,
            NameOfTheField: row.cells[1].querySelector("input").value,
            ApprovedManMonthAsPerPD: row.cells[2].querySelector("input").value,
            ApprovedManMonthAsPerContract: row.cells[3].querySelector("input").value,
            ActualManMonthUtilized: row.cells[4].querySelector("input").value,
            NumberOfDeliverablesAsPerPD: row.cells[5].querySelector("input").value,
            NumberOfDeliverablesActual: row.cells[6].querySelector("input").value,
            Remarks: row.cells[7].querySelector("input").value
        };
        _20ProjectConsultants.push(data);
    });

    console.log(_20ProjectConsultants);

    $.ajax({
        type: "POST",
        url: "/SaveProjectConsultant",
        data: JSON.stringify(_20ProjectConsultants),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            console.log("_20ProjectConsultant data saved:", response);
            // alert("_20ProjectConsultant saved successfully!");
        },
        error: function (error) {
            console.error("Error saving _20ProjectConsultant data:", error.responseText);
            alert("Error saving _20ProjectConsultant data: " + error.responseText);
        }
    });
}

function saveInfrastructureErectionInstalationData(projectId) {

    var _21InfrastructureErectionInstalations = [];

    const table = document.getElementById("secB_ToolsEquipTable");
    const tableRows = table.querySelectorAll("tr:not(:first-child):not(:nth-child(2)):not(:nth-child(3))");

    tableRows.forEach(row => {
        const data = {
            ProjectId: projectId,
            Description: row.cells[0].querySelector("input").value,
            QuantityAsPerProjectDocument: row.cells[1].querySelector("input").value,
            QuantityProcured: row.cells[2].querySelectorAll("input")[0].value,
            QuantityProcuredDate: row.cells[2].querySelectorAll("input")[1].value,
            TransferredToOM: row.cells[3].querySelectorAll("input")[0].value,
            TransferredToOMDate: row.cells[3].querySelectorAll("input")[1].value,
            DisposedOff: row.cells[4].querySelectorAll("input")[0].value,
            DisposedOffDate: row.cells[4].querySelectorAll("input")[1].value,
            Balance: row.cells[5].querySelector("input").value,
            Remarks: row.cells[6].querySelector("input").value
        };
        _21InfrastructureErectionInstalations.push(data);
    });

    console.log(_21InfrastructureErectionInstalations);

    $.ajax({
        type: "POST",
        url: "/SaveInfrastructureErectionInstalation",
        data: JSON.stringify(_21InfrastructureErectionInstalations),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            console.log("_21InfrastructureErectionInstalation data saved:", response);
            // alert("_21InfrastructureErectionInstalation saved successfully!");
        },
        error: function (error) {
            console.error("Error saving _21InfrastructureErectionInstalation data:", error.responseText);
            alert("Error saving _21InfrastructureErectionInstalation data: " + error.responseText);
        }
    });
}

function saveInfoOnPackageData(projectId) {

    var payload = {
        ProjectId: projectId,
        TotalPackagesAsPerPD: $("#totalPackagesAsPerPD").val(),
        GoodsAsPerPD: $("#goodsAsPerPD").val(),
        WorksAsPerPD: $("#worksAsPerPD").val(),
        ServicesAsPerPD: $("#servicesAsPerPD").val(),
        TotalPackagesProcured: $("#totalPackagesProcured").val(),
        GoodsProcured: $("#goodsProcured").val(),
        WorksProcured: $("#worksProcured").val(),
        ServicesProcured: $("#servicesProcured").val(),
        ReasonForNotProcuring: $("#reasonForNotProcuring").val(),
        TotalPackagesMoreThanOnePct: $("#totalPackagesMoreThanOnePct").val(),
        GoodsMoreThanOnePct: $("#goodsMoreThanOnePct").val(),
        WorksMoreThanOnePct: $("#worksMoreThanOnePct").val(),
        ServicesMoreThanOnePct: $("#servicesMoreThanOnePct").val()
    };

    console.log(payload);

    $.ajax({
        type: "POST",
        url: "/SaveInfoOnPackage",
        data: JSON.stringify(payload),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            console.log("_22_1InfoOnPackage data saved:", response);
            // alert("_22_1InfoOnPackage saved successfully!");
        },
        error: function (error) {
            console.error("Error saving _22_1InfoOnPackage data:", error.responseText);
            alert("Error saving _22_1InfoOnPackage data: " + error.responseText);
        }
    });
}

function saveOriginalAndRevisedProvisionTargetData(projectId) {

    var _23OriginalAndRevisedProvisionTargets = [];

    const table = document.getElementById("secC_FinProvPhyTgtTable");
    const tableRows = table.querySelectorAll("tr:not(:first-child):not(:nth-child(2)):not(:nth-child(3)):not(:nth-child(4))");

    tableRows.forEach(row => {
        const data = {
            ProjectId: projectId,
            FinancialYear: row.cells[0].querySelector("input").value,
            TotalOriginal: row.cells[1].querySelector("input").value,
            GOBOriginal: row.cells[2].querySelector("input").value,
            PAOriginal: row.cells[3].querySelector("input").value,
            SelfFinanceOriginal: row.cells[4].querySelector("input").value,
            OthersOriginal: row.cells[5].querySelector("input").value,
            PhysicalPercentageOriginal: row.cells[6].querySelector("input").value,
            TotalRevised: row.cells[7].querySelector("input").value,
            GOBRevised: row.cells[8].querySelector("input").value,
            PARevised: row.cells[9].querySelector("input").value,
            SelfFinanceRevised: row.cells[10].querySelector("input").value,
            OthersRevised: row.cells[11].querySelector("input").value,
            PhysicalPercentageRevised: row.cells[12].querySelector("input").value
        };
        _23OriginalAndRevisedProvisionTargets.push(data);
    });

    console.log(_23OriginalAndRevisedProvisionTargets);

    $.ajax({
        type: "POST",
        url: "/SaveOriginalAndRevisedProvisionTarget",
        data: JSON.stringify(_23OriginalAndRevisedProvisionTargets),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            console.log("_23OriginalAndRevisedProvisionTarget data saved:", response);
            // alert("_23OriginalAndRevisedProvisionTarget saved successfully!");
        },
        error: function (error) {
            console.error("Error saving _23OriginalAndRevisedProvisionTarget data:", error.responseText);
            alert("Error saving _23OriginalAndRevisedProvisionTarget data: " + error.responseText);
        }
    });
}

function saveRevisedADPAllocationAndProgressData(projectId) {

    var _24RevisedADPAllocationAndProgresses = [];

    const table = document.getElementById("secC_RevAdpTable");
    const tableRows = table.querySelectorAll("tr:not(:first-child):not(:nth-child(2)):not(:nth-child(3)):not(:nth-child(4))");

    tableRows.forEach(row => {
        const data = {
            ProjectId: projectId,
            FinancialYear: row.cells[0].querySelector("input").value,
            TotalAllocation: row.cells[1].querySelector("input").value,
            GOBAllocation: row.cells[2].querySelector("input").value,
            PAAllocation: row.cells[3].querySelector("input").value,
            SelfFinanceAllocation: row.cells[4].querySelector("input").value,
            OthersAllocation: row.cells[5].querySelector("input").value,
            PhysicalPercentageAllocation: row.cells[6].querySelector("input").value,
            GOBRelease: row.cells[7].querySelector("input").value,
            TotalProgress: row.cells[8].querySelector("input").value,
            GOBProgress: row.cells[9].querySelector("input").value,
            PAProgress: row.cells[10].querySelector("input").value,
            SelfFinanceProgress: row.cells[11].querySelector("input").value,
            OthersProgress: row.cells[12].querySelector("input").value,
            PhysicalPercentageProgress: row.cells[13].querySelector("input").value,
            UnspentGOBReleased: row.cells[14].querySelector("input").value
        };
        _24RevisedADPAllocationAndProgresses.push(data);
    });

    console.log(_24RevisedADPAllocationAndProgresses);

    $.ajax({
        type: "POST",
        url: "/SaveRevisedADPAllocationAndProgress",
        data: JSON.stringify(_24RevisedADPAllocationAndProgresses),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            console.log("_24RevisedADPAllocationAndProgress data saved:", response);
            // alert("_24RevisedADPAllocationAndProgress saved successfully!");
        },
        error: function (error) {
            console.error("Error saving _24RevisedADPAllocationAndProgress data:", error.responseText);
            alert("Error saving _24RevisedADPAllocationAndProgress data: " + error.responseText);
        }
    });
}

function saveObjectiveAchievementData(projectId) {

    var _25ObjectiveAchievements = [];

    const table = document.getElementById("secD_PrjAchievementTable");
    const tableRows = table.querySelectorAll("tr:not(:first-child):not(:nth-child(2))");

    tableRows.forEach(row => {
        const data = {
            ProjectId: projectId,
            Objective: row.cells[1].querySelector("textarea").value,
            Achievement: row.cells[2].querySelector("textarea").value,
            ReasonsForShortfall: row.cells[3].querySelector("textarea").value
        };
        _25ObjectiveAchievements.push(data);
    });

    console.log(_25ObjectiveAchievements);

    $.ajax({
        type: "POST",
        url: "/SaveObjectiveAchievement",
        data: JSON.stringify(_25ObjectiveAchievements),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            console.log("_25ObjectiveAchievement data saved:", response);
            // alert("_25ObjectiveAchievement saved successfully!");
        },
        error: function (error) {
            console.error("Error saving _25ObjectiveAchievement data:", error.responseText);
            alert("Error saving _25ObjectiveAchievement data: " + error.responseText);
        }
    });
}

function saveAnnualOutputData(projectId) {

    var _26AnnualOutputs = [];

    const table = document.getElementById("secE_AnnOutTable");
    const tableRows = table.querySelectorAll("tr:not(:first-child):not(:nth-child(2))");

    tableRows.forEach(row => {
        const data = {
            ProjectId: projectId,
            Item: row.cells[1].querySelector("input").value,
            Unit: row.cells[2].querySelector("input").value,
            EstimatedQuantity: row.cells[3].querySelector("textarea").value,
            ActualQuantity: row.cells[4].querySelector("textarea").value
        };
        _26AnnualOutputs.push(data);
    });

    console.log(_26AnnualOutputs);

    $.ajax({
        type: "POST",
        url: "/SaveAnnualOutput",
        data: JSON.stringify(_26AnnualOutputs),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            console.log("_26AnnualOutput data saved:", response);
            // alert("_26AnnualOutput saved successfully!");
        },
        error: function (error) {
            console.error("Error saving _26AnnualOutput data:", error.responseText);
            alert("Error saving _26AnnualOutput data: " + error.responseText);
        }
    });
}

function saveCostBenefitData(projectId) {

    var _27CostBenefits = [];

    const table = document.getElementById("secE_CostBenifitTable");
    const tableRows = table.querySelectorAll("tr:not(:first-child):not(:nth-child(2))");

    tableRows.forEach(row => {
        const data = {
            ProjectId: projectId,
            Category: row.cells[0].querySelector("select").value,
            Item: row.cells[1].querySelector("select").value,
            Estimated: row.cells[2].querySelector("input").value,
            Actual: row.cells[3].querySelector("input").value
        };
        _27CostBenefits.push(data);
    });

    console.log(_27CostBenefits);

    $.ajax({
        type: "POST",
        url: "/SaveCostBenefit",
        data: JSON.stringify(_27CostBenefits),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            console.log("_27CostBenefit data saved:", response);
            // alert("_27CostBenefit saved successfully!");
        },
        error: function (error) {
            console.error("Error saving _27CostBenefit data:", error.responseText);
            alert("Error saving _27CostBenefit data: " + error.responseText);
        }
    });
}

function saveMonitoringData(projectId) {

    var _29Monitorings = [];

    const table = document.getElementById("secF_MonitorTable");
    const tableRows = table.querySelectorAll("tr:not(:first-child):not(:nth-child(2))");

    tableRows.forEach(row => {
        const data = {
            ProjectId: projectId,
            Category: row.cells[0].querySelector("select").value,
            NameAndDesignation: row.cells[1].querySelector("textarea").value,
            Date: row.cells[2].querySelector("input").value,
            IdentifiedProblems: row.cells[3].querySelector("textarea").value,
            Recommendations: row.cells[4].querySelector("textarea").value
        };
        _29Monitorings.push(data);
    });

    console.log(_29Monitorings);

    $.ajax({
        type: "POST",
        url: "/SaveMonitoring",
        data: JSON.stringify(_29Monitorings),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            console.log("_29Monitoring data saved:", response);
            // alert("_29Monitoring saved successfully!");
        },
        error: function (error) {
            console.error("Error saving _29Monitoring data:", error.responseText);
            alert("Error saving _29Monitoring data: " + error.responseText);
        }
    });
}

function saveInternalAuditData(projectId) {

    var _30_1InternalAudits = [];

    const table = document.getElementById("secF_IntAuditTable");
    const tableRows = table.querySelectorAll("tr:not(:first-child):not(:nth-child(2)):not(:nth-child(3)):not(:nth-last-child(1))");

    tableRows.forEach(row => {
        const data = {
            ProjectId: projectId,
            StartDate: row.cells[1].querySelectorAll("input")[0].value,
            EndDate: row.cells[1].querySelectorAll("input")[1].value,
            SubmissionDate: row.cells[2].querySelector("input").value,
            MajorFindings: row.cells[3].querySelector("textarea").value,
            WhetherObjectionsResolved: row.cells[4].querySelector("textarea").value
        };
        _30_1InternalAudits.push(data);
    });

    console.log(_30_1InternalAudits);

    $.ajax({
        type: "POST",
        url: "/SaveInternalAudit",
        data: JSON.stringify(_30_1InternalAudits),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            console.log("_30_1InternalAudit data saved:", response);
            // alert("_30_1InternalAudit saved successfully!");
        },
        error: function (error) {
            console.error("Error saving _30_1InternalAudit data:", error.responseText);
            alert("Error saving _30_1InternalAudit data: " + error.responseText);
        }
    });
}

function saveExternalAuditData(projectId) {

    var _30_2ExternalAudits = [];

    const table = document.getElementById("secF_ExtAuditTable");
    const tableRows = table.querySelectorAll("tr:not(:first-child):not(:nth-child(2)):not(:nth-child(3)):not(:nth-last-child(1))");

    tableRows.forEach(row => {
        const data = {
            ProjectId: projectId,
            StartDate: row.cells[1].querySelectorAll("input")[0].value,
            EndDate: row.cells[1].querySelectorAll("input")[1].value,
            SubmissionDate: row.cells[2].querySelector("input").value,
            MajorFindings: row.cells[3].querySelector("textarea").value,
            WhetherObjectionsResolved: row.cells[4].querySelector("textarea").value
        };
        _30_2ExternalAudits.push(data);
    });

    console.log(_30_2ExternalAudits);

    $.ajax({
        type: "POST",
        url: "/SaveExternalAudit",
        data: JSON.stringify(_30_2ExternalAudits),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            console.log("_30_2ExternalAudit data saved:", response);
            // alert("_30_2ExternalAudit saved successfully!");
        },
        error: function (error) {
            console.error("Error saving _30_2ExternalAudit data:", error.responseText);
            alert("Error saving _30_2ExternalAudit data: " + error.responseText);
        }
    });
}

function saveAuditingData(projectId) {

    var payload = {
        ProjectId: projectId,
        TotalInternalMajorFindings: $("#totalInternalMajorFindings").val(),
        TotalInternalWhetherResolved: $("#totalInternalWhetherResolved").val(),
        TotalExternalMajorFindings: $("#totalExternalMajorFindings").val(),
        TotalExternalWhetherResolved: $("#totalExternalWhetherResolved").val()
    };

    console.log(payload);

    $.ajax({
        type: "POST",
        url: "/SaveAuditing",
        data: JSON.stringify(payload),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            console.log("_30Auditing data saved:", response);
            // alert("_30Auditing saved successfully!");
        },
        error: function (error) {
            console.error("Error saving _30Auditing data:", error.responseText);
            alert("Error saving _30Auditing data: " + error.responseText);
        }
    });
}

function savePostProjectRemarkData(projectId) {
    var formData = new FormData();

    // Add ProjectId
    formData.append("ProjectId", projectId);

    // Add Section G text fields (explicitly listed as per your version)
    formData.append("Background", $("#background").val() || "");
    formData.append("JustificationAdequacy", $("#justificationAdequacy").val() || "");
    formData.append("Objectives", $("#objectives").val() || "");
    formData.append("ProjectRevisionWithReasons", $("#projectRevisionWithReasons").val() || "");
    formData.append("Concept", $("#concept").val() || "");
    formData.append("Design", $("#design").val() || "");
    formData.append("Location", $("#location").val() || "");
    formData.append("Timing", $("#timing").val() || "");
    formData.append("ProjectIdentification", $("#projectIdentification").val() || "");
    formData.append("ProjectPreparation", $("#projectPreparation").val() || "");
    formData.append("Appraisal", $("#appraisal").val() || "");
    formData.append("CreditNegotiation", $("#creditNegotiation").val() || "");
    formData.append("CreditAgreement", $("#creditAgreement").val() || "");
    formData.append("CreditEffectiveness", $("#creditEffectiveness").val() || "");
    formData.append("LoanDisbursement", $("#loanDisbursement").val() || "");
    formData.append("LoanConditions", $("#loanConditions").val() || "");
    formData.append("ProjectApproval", $("#projectApproval").val() || "");
    formData.append("OthersSpecify", $("#othersSpecify").val() || "");
    formData.append("_34_1", $("#_34_1").val() || "");
    formData.append("_34_2", $("#_34_2").val() || "");
    formData.append("_34_3", $("#_34_3").val() || "");
    formData.append("_34_4", $("#_34_4").val() || "");
    formData.append("_34_5", $("#_34_5").val() || "");
    formData.append("_34_6", $("#_34_6").val() || "");
    formData.append("_34_7", $("#_34_7").val() || "");
    formData.append("_34_8", $("#_34_8").val() || "");
    formData.append("_34_9", $("#_34_9").val() || "");
    formData.append("_34_10", $("#_34_10").val() || "");
    formData.append("_34_11", $("#_34_11").val() || "");
    formData.append("_34_12", $("#_34_12").val() || "");
    formData.append("_34_13", $("#_34_13").val() || "");
    formData.append("_34_14", $("#_34_14").val() || "");
    formData.append("_34_15", $("#_34_15").val() || "");
    formData.append("_35_1", $("#_35_1").val() || "");
    formData.append("_35_2", $("#_35_2").val() || "");
    formData.append("_35_3", $("#_35_3").val() || "");
    formData.append("_35_4", $("#_35_4").val() || "");
    formData.append("_35_5", $("#_35_5").val() || "");
    formData.append("_35_6", $("#_35_6").val() || "");
    formData.append("_35_7", $("#_35_7").val() || "");
    formData.append("_35_8", $("#_35_8").val() || "");
    formData.append("_35_9", $("#_35_9").val() || "");
    formData.append("_35_10", $("#_35_10").val() || "");
    formData.append("_35_11", $("#_35_11").val() || "");
    formData.append("_35_12", $("#_35_12").val() || "");
    formData.append("_35_13", $("#_35_13").val() || "");
    formData.append("_35_14", $("#_35_14").val() || "");
    formData.append("_35_15", $("#_35_15").val() || "");
    formData.append("_35_16", $("#_35_16").val() || "");
    formData.append("_35_17", $("#_35_17").val() || "");
    formData.append("_35_18", $("#_35_18").val() || "");
    formData.append("_35_19", $("#_35_19").val() || "");
    formData.append("_28ReasonsForShortFall", $("#_28ReasonsForShortFall").val() || "");

    // Add remarks and dates from PD, AH, and Secretary sections
    formData.append("_36RemarksPD", $("#_36RemarksPD").val() || "");
    formData.append("_36DatePD", $("#_36DatePD").val() || "");
    formData.append("_36RemarksAH", $("#_36RemarksAH").val() || "");
    formData.append("_36DateAH", $("#_36DateAH").val() || "");
    formData.append("_36RemarksSec", $("#_36RemarksSec").val() || "");
    formData.append("_36DateSec", $("#_36DateSec").val() || "");

    // Add signature and seal files with logging
    const signPDInput = $("#pdSignInput")[0];
    const signPDFile = signPDInput && signPDInput.files[0];
    if (signPDFile) {
        console.log("SignPD File:", signPDFile.name, signPDFile.size);
        formData.append("_36SignPD", signPDFile);
    } else {
        console.log("No SignPD file selected");
    }

    const sealPDInput = $("#pdSealInput")[0];
    const sealPDFile = sealPDInput && sealPDInput.files[0];
    if (sealPDFile) {
        console.log("SealPD File:", sealPDFile.name, sealPDFile.size);
        formData.append("_36SealPD", sealPDFile);
    } else {
        console.log("No SealPD file selected");
    }

    const signAHInput = $("#ahSignInput")[0];
    const signAHFile = signAHInput && signAHInput.files[0];
    if (signAHFile) {
        console.log("SignAH File:", signAHFile.name, signAHFile.size);
        formData.append("_36SignAH", signAHFile);
    } else {
        console.log("No SignAH file selected");
    }

    const sealAHInput = $("#ahSealInput")[0];
    const sealAHFile = sealAHInput && sealAHInput.files[0];
    if (sealAHFile) {
        console.log("SealAH File:", sealAHFile.name, sealAHFile.size);
        formData.append("_36SealAH", sealAHFile);
    } else {
        console.log("No SealAH file selected");
    }

    const signSecInput = $("#secSignInput")[0];
    const signSecFile = signSecInput && signSecInput.files[0];
    if (signSecFile) {
        console.log("SignSec File:", signSecFile.name, signSecFile.size);
        formData.append("_36SignSec", signSecFile);
    } else {
        console.log("No SignSec file selected");
    }

    const sealSecInput = $("#secSealInput")[0];
    const sealSecFile = sealSecInput && sealSecInput.files[0];
    if (sealSecFile) {
        console.log("SealSec File:", sealSecFile.name, sealSecFile.size);
        formData.append("_36SealSec", sealSecFile);
    } else {
        console.log("No SealSec file selected");
    }

    console.log("FormData prepared:", formData);

    $.ajax({
        type: "POST",
        url: "/SavePostProjectRemark",
        data: formData,
        contentType: false,
        processData: false,
        success: function (response) {
            console.log("_G_PostProjectRemark data saved:", response);
        },
        error: function (error) {
            console.error("Error saving _G_PostProjectRemark data:", error.responseText);
            alert("Error saving _G_PostProjectRemark data: " + error.responseText);
        }
    });
}

function saveProcurementGoodsData(projectId) {
    var procurementGoodsList = [];

    const goodsTable = document.getElementById("annexure1a_GoodsTable");
    const goodsRows = goodsTable.querySelectorAll("tr:not(:first-child):not(:nth-child(2)):not(:nth-child(3)):not(:nth-child(4))");

    for (let i = 0; i < goodsRows.length; i += 3) {
        const planRow = goodsRows[i];
        const actualRow = goodsRows[i + 1];
        const deviationRow = goodsRows[i + 2];

        const goods = {
            ProjectId: projectId,
            PackageNo: planRow.cells[0].querySelector("textarea").value,
            DescriptionOfPackage: planRow.cells[1].querySelector("textarea").value,
            PlanEstimatedCost: planRow.cells[2].querySelector("input").value,
            PlanProcurementMethod: planRow.cells[3].querySelector("input").value,
            PlanApprovingAuthority: planRow.cells[4].querySelector("input").value,
            PlanDateOfTenderInvitation: planRow.cells[5].querySelector("input").value,
            NameOfNewspaper: planRow.cells[6].querySelector("textarea").value,
            PlanDateOfOpening: planRow.cells[7].querySelector("input").value,
            PlanDateOfApproval: planRow.cells[8].querySelector("input").value,
            PlanDateOfNOA: planRow.cells[9].querySelector("input").value,
            ContractPrice: planRow.cells[10].querySelectorAll("input")[0].value,
            ContractDate: planRow.cells[10].querySelectorAll("input")[1].value,
            ActualPayment: planRow.cells[11].querySelector("textarea").value,
            CompletionDateAsPerContract: planRow.cells[12].querySelector("input").value,
            CompletionDateActual: planRow.cells[13].querySelector("input").value,
            ActualEstimatedCost: actualRow.cells[0].querySelector("input").value,
            ActualProcurementMethod: actualRow.cells[1].querySelector("input").value,
            ActualApprovingAuthority: actualRow.cells[2].querySelector("input").value,
            ActualDateOfTenderInvitation: actualRow.cells[3].querySelector("input").value,
            ActualDateOfOpening: actualRow.cells[4].querySelector("input").value,
            ActualDateOfApproval: actualRow.cells[5].querySelector("input").value,
            ActualDateOfNOA: actualRow.cells[6].querySelector("input").value,
            DeviationEstimatedCost: deviationRow.cells[0].querySelector("input").value,
            DeviationProcurementMethod: deviationRow.cells[1].querySelector("input").value,
            DeviationApprovingAuthority: deviationRow.cells[2].querySelector("input").value,
            DeviationDateOfTenderInvitation: deviationRow.cells[3].querySelector("input").value,
            DeviationDateOfOpening: deviationRow.cells[4].querySelector("input").value,
            DeviationDateOfApproval: deviationRow.cells[5].querySelector("input").value,
            DeviationDateOfNOA: deviationRow.cells[6].querySelector("input").value
        };

        procurementGoodsList.push(goods);
    }

    console.log(procurementGoodsList);

    $.ajax({
        type: "POST",
        url: "/SaveProcurementGood",
        data: JSON.stringify(procurementGoodsList),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            console.log("Procurement goods data saved:", response);
        },
        error: function (error) {
            console.error("Error saving procurement goods data:", error.responseText);
            alert("Error saving procurement goods data: " + error.responseText);
        }
    });
}

function saveProcurementWorksData(projectId) {
    var procurementWorksList = [];

    const worksTable = document.getElementById("annexure1b_WorksTable");
    const worksRows = worksTable.querySelectorAll("tr:not(:first-child):not(:nth-child(2)):not(:nth-child(3)):not(:nth-child(4))");

    for (let i = 0; i < worksRows.length; i += 3) {
        const planRow = worksRows[i];
        const actualRow = worksRows[i + 1];
        const deviationRow = worksRows[i + 2];

        const works = {
            ProjectId: projectId,
            PackageNo: planRow.cells[0].querySelector("textarea").value,
            DescriptionOfPackage: planRow.cells[1].querySelector("textarea").value,
            PlanEstimatedCost: planRow.cells[2].querySelector("input").value,
            PlanProcurementMethod: planRow.cells[3].querySelector("input").value,
            PlanApprovingAuthority: planRow.cells[4].querySelector("input").value,
            PlanDateOfTenderInvitation: planRow.cells[5].querySelector("input").value,
            NameOfNewspaper: planRow.cells[6].querySelector("textarea").value,
            PlanDateOfOpening: planRow.cells[7].querySelector("input").value,
            PlanDateOfApproval: planRow.cells[8].querySelector("input").value,
            PlanDateOfNOA: planRow.cells[9].querySelector("input").value,
            ContractPrice: planRow.cells[10].querySelectorAll("input")[0].value,
            ContractDate: planRow.cells[10].querySelectorAll("input")[1].value,
            ActualPayment: planRow.cells[11].querySelector("textarea").value,
            CompletionDateAsPerContract: planRow.cells[12].querySelector("input").value,
            CompletionDateActual: planRow.cells[13].querySelector("input").value,
            ActualEstimatedCost: actualRow.cells[0].querySelector("input").value,
            ActualProcurementMethod: actualRow.cells[1].querySelector("input").value,
            ActualApprovingAuthority: actualRow.cells[2].querySelector("input").value,
            ActualDateOfTenderInvitation: actualRow.cells[3].querySelector("input").value,
            ActualDateOfOpening: actualRow.cells[4].querySelector("input").value,
            ActualDateOfApproval: actualRow.cells[5].querySelector("input").value,
            ActualDateOfNOA: actualRow.cells[6].querySelector("input").value,
            DeviationEstimatedCost: deviationRow.cells[0].querySelector("input").value,
            DeviationProcurementMethod: deviationRow.cells[1].querySelector("input").value,
            DeviationApprovingAuthority: deviationRow.cells[2].querySelector("input").value,
            DeviationDateOfTenderInvitation: deviationRow.cells[3].querySelector("input").value,
            DeviationDateOfOpening: deviationRow.cells[4].querySelector("input").value,
            DeviationDateOfApproval: deviationRow.cells[5].querySelector("input").value,
            DeviationDateOfNOA: deviationRow.cells[6].querySelector("input").value
        };

        procurementWorksList.push(works);
    }

    console.log(procurementWorksList);

    $.ajax({
        type: "POST",
        url: "/SaveProcurementWork",
        data: JSON.stringify(procurementWorksList),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            console.log("Procurement works data saved:", response);
        },
        error: function (error) {
            console.error("Error saving procurement works data:", error.responseText);
            alert("Error saving procurement works data: " + error.responseText);
        }
    });
}

function saveProcurementServicesData(projectId) {
    var procurementServicesList = [];

    const servicesTable = document.getElementById("annexure1c_ServicesTable");
    const servicesRows = servicesTable.querySelectorAll("tr:not(:first-child):not(:nth-child(2)):not(:nth-child(3)):not(:nth-child(4))");

    for (let i = 0; i < servicesRows.length; i += 3) {
        const planRow = servicesRows[i];
        const actualRow = servicesRows[i + 1];
        const deviationRow = servicesRows[i + 2];

        const services = {
            ProjectId: projectId,
            PackageNo: planRow.cells[0].querySelector("textarea").value,
            DescriptionOfPackage: planRow.cells[1].querySelector("textarea").value,
            PlanEstimatedCost: planRow.cells[2].querySelector("input").value,
            PlanProcurementMethod: planRow.cells[3].querySelector("input").value,
            PlanApprovingAuthority: planRow.cells[4].querySelector("input").value,
            PlanDateOfTenderInvitation: planRow.cells[5].querySelector("input").value,
            NameOfNewspaper: planRow.cells[6].querySelector("textarea").value,
            PlanDateOfOpening: planRow.cells[7].querySelector("input").value,
            PlanDateOfApproval: planRow.cells[8].querySelector("input").value,
            PlanDateOfNOA: planRow.cells[9].querySelector("input").value,
            ContractPrice: planRow.cells[10].querySelectorAll("input")[0].value,
            ContractDate: planRow.cells[10].querySelectorAll("input")[1].value,
            ActualPayment: planRow.cells[11].querySelector("textarea").value,
            CompletionDateAsPerContract: planRow.cells[12].querySelector("input").value,
            CompletionDateActual: planRow.cells[13].querySelector("input").value,
            ActualEstimatedCost: actualRow.cells[0].querySelector("input").value,
            ActualProcurementMethod: actualRow.cells[1].querySelector("input").value,
            ActualApprovingAuthority: actualRow.cells[2].querySelector("input").value,
            ActualDateOfTenderInvitation: actualRow.cells[3].querySelector("input").value,
            ActualDateOfOpening: actualRow.cells[4].querySelector("input").value,
            ActualDateOfApproval: actualRow.cells[5].querySelector("input").value,
            ActualDateOfNOA: actualRow.cells[6].querySelector("input").value,
            DeviationEstimatedCost: deviationRow.cells[0].querySelector("input").value,
            DeviationProcurementMethod: deviationRow.cells[1].querySelector("input").value,
            DeviationApprovingAuthority: deviationRow.cells[2].querySelector("input").value,
            DeviationDateOfTenderInvitation: deviationRow.cells[3].querySelector("input").value,
            DeviationDateOfOpening: deviationRow.cells[4].querySelector("input").value,
            DeviationDateOfApproval: deviationRow.cells[5].querySelector("input").value,
            DeviationDateOfNOA: deviationRow.cells[6].querySelector("input").value
        };

        procurementServicesList.push(services);
    }

    console.log(procurementServicesList);

    $.ajax({
        type: "POST",
        url: "/SaveProcurementService",
        data: JSON.stringify(procurementServicesList),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            console.log("Procurement services data saved:", response);
        },
        error: function (error) {
            console.error("Error saving procurement services data:", error.responseText);
            alert("Error saving procurement services data: " + error.responseText);
        }
    });
}
