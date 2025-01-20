function PcrForm(){
	this.baseUrl;

	this.initialize = function(_baseUrl){
        this.baseUrl=_baseUrl;
    }

    this.unHideSubMenu = function(id){
        let x = document.getElementById(id);
        if (x.className.indexOf("w3-hide") == -1) {
            x.className += " w3-hide";
            //x.previousElementSibling.className += " w3-theme-d1";
        } else { 
            x.className = x.className.replace("w3-hide", "");
            //x.previousElementSibling.className = x.previousElementSibling.className.replace(" w3-theme-d1", "");
        }
    }

    this._getDivisionList = function(){return '<select class="w3-select"><option value="dhaka">Dhaka</option><option value="chattogram">Chattogram</option><option value="rajshahi">Rajshahi</option><option value="khulna">Khulna</option><option value="sylhet">Sylhet</option><option value="barishal">Barishal</option><option value="rangpur">Rangpur</option><option value="mymensingh">Mymensingh</option>';}

    this._getDistrictList = function(division){return '<select class="w3-select"><option value="dhaka">Dhaka</option><option value="chattogram">Chattogram</option><option value="rajshahi">Rajshahi</option><option value="khulna">Khulna</option><option value="sylhet">Sylhet</option></select>';}

    this._getUpazilaList = function(division, upazila){return '<select class="w3-select"><option value="savarp">Savar</option><option value="raozan">Raozan</option><option value="paba">Paba</option><option value="dumuria">Dumuria</option><option value="beanibazar">Beanibazar</option></select>';}

    this.secA_LocationTable_Add = function(){
        let table = document.getElementById("secA_LocationTable");
        let row = table.insertRow(-1);
        let tmpCell = row.insertCell(0);
        tmpCell.innerHTML = "0";
        tmpCell = row.insertCell(1);
        tmpCell.innerHTML = this._getDivisionList();
        tmpCell = row.insertCell(2);
        tmpCell.innerHTML = this._getDistrictList();
        tmpCell = row.insertCell(3);
        tmpCell.innerHTML = this._getUpazilaList();
        this.tableReserial("secA_LocationTable",2);
    }

    this.secA_EtimatedCostTable_Add = function(){
        let table = document.getElementById("secA_EtimatedCostTable");
        let row = table.insertRow(-1);
        let tmpCell = row.insertCell(0);
        tmpCell.innerHTML = '<select class="w3-select"><option>Original</option><option>1st Revised</option><option>2nd Revised</option><option>3rd Revised</option><option>4th Revised</option><option>5th Revised</option><option>1st No Cost Extension</option><option>2nd No Cost Extension</option><option>3rd No Cost Extension</option><option>4th No Cost Extension</option><option>5th No Cost Extension</option><option>Intercomponent Adjustment</option></select>';
        tmpCell = row.insertCell(1);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="number">';
        tmpCell = row.insertCell(2);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="number">';
        tmpCell = row.insertCell(3);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="number">';
        tmpCell = row.insertCell(4);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="number">';
        tmpCell = row.insertCell(5);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="number">';
        tmpCell = row.insertCell(6);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="number">';
        tmpCell = row.insertCell(7);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="number">';
    }

    this.secA_LoanStatus_ForeignTable_Add = function(){
        let table = document.getElementById("secA_LoanStatus_ForeignTable");
        let row = table.insertRow(-1);
        let tmpCell = row.insertCell(0);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(1);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(2);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="number">';
        tmpCell = row.insertCell(3);
        tmpCell.innerHTML = '<select class="w3-select"><option>Loan</option><option>Grant</option><option>supplier’s credit</option></select>';
        tmpCell = row.insertCell(4);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="date">';
        tmpCell = row.insertCell(5);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="date">';
        tmpCell = row.insertCell(6);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="date">';
        tmpCell = row.insertCell(7);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="date">';
    }

    this.secA_LoanStatus_GobTable_Add = function(){
        let table = document.getElementById("secA_LoanStatus_GobTable");
        let row = table.insertRow(-1);
        let tmpCell = row.insertCell(0);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="number">';
        tmpCell = row.insertCell(1);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="number">';
        tmpCell = row.insertCell(2);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="number">';
        tmpCell = row.insertCell(3);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
    }

    this.secA_LoanStatus_SelfTable_Add = function(){
        let table = document.getElementById("secA_LoanStatus_SelfTable");
        let row = table.insertRow(-1);
        let tmpCell = row.insertCell(0);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="number">';
        tmpCell = row.insertCell(1);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="number">';
        tmpCell = row.insertCell(2);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="number">';
        tmpCell = row.insertCell(3);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
    }

    this.secA_UtilizationTable_Add = function(){
        let table = document.getElementById("secA_UtilizationTable");
        let row = table.insertRow(-1);
        let tmpCell = row.insertCell(0);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(1);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="number">';
        tmpCell = row.insertCell(2);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="number">';
        tmpCell = row.insertCell(3);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="number">';
        tmpCell = row.insertCell(4);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="number">';
        tmpCell = row.insertCell(5);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="number">';
        tmpCell = row.insertCell(6);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="number">';
    }

    this.secA_RpaTable_Add = function(){
        let table = document.getElementById("secA_RpaTable");
        let row = table.insertRow(-1);
        let tmpCell = row.insertCell(0);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(1);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="number">';
        tmpCell = row.insertCell(2);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="number">';
        tmpCell = row.insertCell(3);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="number">';
        tmpCell = row.insertCell(4);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="number">';
        tmpCell = row.insertCell(5);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="number">';
        tmpCell = row.insertCell(6);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
    }

    this.secB_ImplPeriodTable_Add = function(){
        let table = document.getElementById("secB_ImplPeriodTable");
        let row = table.insertRow(-1);
        let tmpCell = row.insertCell(0);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="number">';
        tmpCell = row.insertCell(1);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="number">';
        tmpCell = row.insertCell(2);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="number">';
        tmpCell = row.insertCell(3);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="number">';
        tmpCell = row.insertCell(4);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
    }

    this.secB_PrjCostTable_Add = function(){
        let table = document.getElementById("secB_PrjCostTable");
        let row = table.insertRow(-1);
        let tmpCell = row.insertCell(0);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(1);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="number">';
        tmpCell = row.insertCell(2);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="number">';
        tmpCell = row.insertCell(3);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="number">';
        tmpCell = row.insertCell(4);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="number">';
        tmpCell = row.insertCell(5);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
    }

    this.secB_PdInfoTable_Add = function(){
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

    this.secB_PiuTable_Add = function(){
        let table = document.getElementById("secB_PiuTable");
        let row = table.insertRow(table.rows.length-1);
        let tmpCell = row.insertCell(0);
        tmpCell.innerHTML = "0";
        tmpCell = row.insertCell(1);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="number">';
        tmpCell = row.insertCell(2);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="number">';
        tmpCell = row.insertCell(3);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="number">';
        this.tableReserial("secB_PiuTable",3,true);
        //this.tableSum("secB_PiuTable",3,[1,2,3]);
    }

    this.secB_PerReqAftComTable_Add = function(){
        let table = document.getElementById("secB_PerReqAftComTable");
        let row = table.insertRow(table.rows.length-1);
        let tmpCell = row.insertCell(0);
        tmpCell.innerHTML = "0";
        tmpCell = row.insertCell(1);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(2);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="number">';
        tmpCell = row.insertCell(3);
        tmpCell.innerHTML = '<select class="w3-select"><option>Yes</option><option>No</option></select>';
        tmpCell = row.insertCell(4);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        this.tableReserial("secB_PerReqAftComTable",4,true);
        //this.tableSum("secB_PiuTable",3,[1,2,3]);
    }

    this.secB_TrainingTable_Add = function(){
        let table = document.getElementById("secB_TrainingTable");
        let row = table.insertRow(table.rows.length-1);
        let tmpCell = row.insertCell(0);
        tmpCell.innerHTML = "0";
        tmpCell = row.insertCell(1);
        tmpCell.innerHTML = '<select class="w3-select"><option>Local Training</option><option>Foreign Training</option></select>';
        tmpCell = row.insertCell(2);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="number">';
        tmpCell = row.insertCell(3);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="number">';
        tmpCell = row.insertCell(4);
        tmpCell.innerHTML = '<textarea class="w3-input w3-border w3-round-large"></textarea>';
        tmpCell = row.insertCell(5);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="number">';
        tmpCell = row.insertCell(6);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="number">';
        tmpCell = row.insertCell(7);
        tmpCell.innerHTML = '<textarea class="w3-input w3-border w3-round-large"></textarea>';
        this.tableReserial("secB_TrainingTable",5,true);
        //this.tableSum("secB_PiuTable",3,[1,2,3]);
    }

    this.secB_CompWiseProgressTable_Add = function(){
        let table = document.getElementById("secB_CompWiseProgressTable");
        let row = table.insertRow(table.rows.length-3);
        let tmpCell = row.insertCell(0);
        tmpCell.innerHTML = '<select class="w3-select"><option>Revenue</option><option>Capital</option></select>';
        tmpCell = row.insertCell(1);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(2);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="number">';
        tmpCell = row.insertCell(3);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="number">';
        tmpCell = row.insertCell(4);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="number">';
        tmpCell = row.insertCell(5);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="number">';
        tmpCell = row.insertCell(6);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="number">';
        tmpCell = row.insertCell(7);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="number">';
        tmpCell = row.insertCell(8);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="number">';
        tmpCell = row.insertCell(9);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="number">';
        tmpCell = row.insertCell(10);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="number">';
        tmpCell = row.insertCell(11);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="number">';
        tmpCell = row.insertCell(12);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="number">';
        tmpCell = row.insertCell(13);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="number">';
        //this.tableSum("secB_PiuTable",3,[1,2,3]);
    }

    this.secB_ProcureTransportTable_Add = function(){
        let table = document.getElementById("secB_ProcureTransportTable");
        let row = table.insertRow(-1);
        let tmpCell = row.insertCell(0);
        tmpCell.innerHTML = '<select class="w3-select"><option>Car</option><option>Jeep</option><option>Microbus</option><option>Minibus</option><option>Bus</option><option>Pick-up</option><option>Truck</option><option>Motor-Cycle</option><option>By-cycle</option><option>Speed Boat</option><option>Launch</option><option>Other</option></select>';
        tmpCell = row.insertCell(1);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="number">';
        tmpCell = row.insertCell(2);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="number"><input class="w3-input w3-border w3-round-large" type="date">';
        tmpCell = row.insertCell(3);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="number"><input class="w3-input w3-border w3-round-large" type="date">';
        tmpCell = row.insertCell(4);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="number"><input class="w3-input w3-border w3-round-large" type="date">';
        tmpCell = row.insertCell(5);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="number"><input class="w3-input w3-border w3-round-large" type="date">';
        tmpCell = row.insertCell(6);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="number"><input class="w3-input w3-border w3-round-large" type="date">';
        tmpCell = row.insertCell(7);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
    }

    this.secB_PrjConsultantTable_Add = function(){
        let table = document.getElementById("secB_PrjConsultantTable");
        let row = table.insertRow(-1);
        let tmpCell = row.insertCell(0);
        tmpCell.innerHTML = '<select class="w3-select"><option>Local</option><option>Foreign</option></select>';
        tmpCell = row.insertCell(1);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(2);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="number">';
        tmpCell = row.insertCell(3);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="number">';
        tmpCell = row.insertCell(4);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="number">';
        tmpCell = row.insertCell(5);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="number">';
        tmpCell = row.insertCell(6);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="number">';
        tmpCell = row.insertCell(7);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
    }

    this.secB_ToolsEquipTable_Add = function(){
        let table = document.getElementById("secB_ToolsEquipTable");
        let row = table.insertRow(-1);
        let tmpCell = row.insertCell(0);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
        tmpCell = row.insertCell(1);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="number">';
        tmpCell = row.insertCell(2);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="number">';
        tmpCell = row.insertCell(3);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="date">';
        tmpCell = row.insertCell(4);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="date">';
        tmpCell = row.insertCell(5);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="number">';
        tmpCell = row.insertCell(6);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="text">';
    }

    this.secC_FinProvPhyTgtTable_Add = function(){
        let table = document.getElementById("secC_FinProvPhyTgtTable");
        let row = table.insertRow(-1);
        let tmpCell = row.insertCell(0);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="number">';
        tmpCell = row.insertCell(1);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="number">';
        tmpCell = row.insertCell(2);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="number">';
        tmpCell = row.insertCell(3);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="number">';
        tmpCell = row.insertCell(4);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="number">';
        tmpCell = row.insertCell(5);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="number">';
        tmpCell = row.insertCell(6);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="number">';
        tmpCell = row.insertCell(7);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="number">';
        tmpCell = row.insertCell(8);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="number">';
        tmpCell = row.insertCell(9);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="number">';
        tmpCell = row.insertCell(10);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="number">';
        tmpCell = row.insertCell(11);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="number">';
        tmpCell = row.insertCell(12);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="number">';
    }

    this.secC_RevAdpTable_Add = function(){
        let table = document.getElementById("secC_RevAdpTable");
        let row = table.insertRow(-1);
        let tmpCell = row.insertCell(0);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="number">';
        tmpCell = row.insertCell(1);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="number">';
        tmpCell = row.insertCell(2);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="number">';
        tmpCell = row.insertCell(3);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="number">';
        tmpCell = row.insertCell(4);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="number">';
        tmpCell = row.insertCell(5);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="number">';
        tmpCell = row.insertCell(6);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="number">';
        tmpCell = row.insertCell(7);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="number">';
        tmpCell = row.insertCell(8);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="number">';
        tmpCell = row.insertCell(9);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="number">';
        tmpCell = row.insertCell(10);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="number">';
        tmpCell = row.insertCell(11);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="number">';
        tmpCell = row.insertCell(12);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="number">';
        tmpCell = row.insertCell(13);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="number">';
        tmpCell = row.insertCell(14);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="number">';
    }

    this.secD_PrjAchievementTable_Add = function(){
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
        this.tableReserial("secD_PrjAchievementTable",2);
    }

    this.secE_AnnOutTable_Add = function(){
        let table = document.getElementById("secE_AnnOutTable");
        let row = table.insertRow(-1);
        let tmpCell = row.insertCell(0);
        tmpCell.innerHTML = '0';
        tmpCell = row.insertCell(1);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="number">';
        tmpCell = row.insertCell(2);
        tmpCell.innerHTML = '<textarea class="w3-input w3-border w3-round-large"></textarea>';
        tmpCell = row.insertCell(3);
        tmpCell.innerHTML = '<textarea class="w3-input w3-border w3-round-large"></textarea>';
        tmpCell = row.insertCell(4);
        tmpCell.innerHTML = '<textarea class="w3-input w3-border w3-round-large"></textarea>';
        this.tableReserial("secE_AnnOutTable",2);
    }

    this.secE_CostBenifitTable_Add = function(){
        let table = document.getElementById("secE_CostBenifitTable");
        let row = table.insertRow(-1);
        let tmpCell = row.insertCell(0);
        tmpCell.innerHTML = '<select class="w3-select"><option>Benefit cost ratio of the project</option><option>Internal Rate of Return</option></select>';
        tmpCell = row.insertCell(1);
        tmpCell.innerHTML = '<select class="w3-select"><option>Financial</option><option>Economic</option></select>';
        tmpCell = row.insertCell(2);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="number">';
        tmpCell = row.insertCell(3);
        tmpCell.innerHTML = '<input class="w3-input w3-border w3-round-large" type="number">';
    }

    this.secF_MonitorTable_Add = function(){
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

    this.secF_IntAuditTable_Add = function(){
        let table = document.getElementById("secF_IntAuditTable");
        let row = table.insertRow(table.rows.length-1);
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
        this.tableReserial("secF_IntAuditTable",3,true);
    }

    this.secF_ExtAuditTable_Add = function(){
        let table = document.getElementById("secF_ExtAuditTable");
        let row = table.insertRow(table.rows.length-1);
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
        this.tableReserial("secF_ExtAuditTable",3,true);
    }

    this.tableReserial = function(tblName,startRow,hasTotal=false){
        let rows = document.getElementById(tblName).getElementsByTagName("tr");
        let cnt = 0;
        let len = rows.length;
        if(hasTotal) len -= 1;
        for(let i=startRow;i<len;i++){
            rows[i].getElementsByTagName("td")[0].innerHTML = ++cnt;
        }
    }
    this.removeTableLastRow = function(tblName,fixedTopRowNum,fixedBottomRowNum=0){
        let rows = document.getElementById(tblName).getElementsByTagName("tr");
        if(rows.length>(fixedTopRowNum+fixedBottomRowNum)){
            rows[rows.length-fixedBottomRowNum-1].remove();
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

    this.loadSign = function(divName){
        let img = new Image();
        let width = 300;
        let height = 80;
        const canvas = document.createElement('canvas');
        let file = document.getElementById(divName+"Input").files;
        document.getElementById(divName).innerHTML = "";
        document.getElementById(divName).appendChild(canvas);
        let ctx = canvas.getContext("2d");
        canvas.width = width;
        canvas.height = height;
        let reader = new FileReader();
            reader.onload = (function(e){
                console.log('loaded')
                // document.getElementById('grid').style.backgroundImage = "url("+e.target.result+")";

                img.src = e.target.result
                //img.src = reader.result;
            });
            reader.readAsDataURL(file[0]);

            img.onload = (function(){
                ctx.drawImage(img, 0, 0, width, height);
            });
    }

}