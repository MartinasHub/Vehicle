import { observable, runInAction, decorate } from 'mobx';
import VehicleModelService from '../Common/VehicleModelService';

export default class VehicleModelStore {
constructor(){
    this.VehicleModelService = new VehicleModelService();
}
    vehicleModelData = {
        model: []
    };
    status = "initial";
    searchQuery = "";

    getVehicleModelsAsync = async () => {
        try {
            var params = {
                pageNumber: this.vehicleModelData.pageNumber,
                searchQuery: this.searchQuery,
                isAscending: this.vehicleModelData.isAscending
            };
            const urlParams = new URLSearchParams(Object.entries(params));
            const data = await this.VehicleModelService.get(urlParams)
            runInAction(() => {
                this.vehicleModelData = data;
            });
        } catch (error) {
            runInAction(() => {
                this.status = "error";
            });
        }
    };
    createVehicleModelsAsync = async (model) => {
        try {
            const response = await this.VehicleModelService.post(model);
            if (response.status === 201) {
                runInAction(() => {
                    this.status = "success";
                })
            } 
        } catch (error) {
            runInAction(() => {
                this.status = "error";
            });
        }

    };
    updateVehicleModelsAsync = async (vehicle) => {
        try {
            const response = await this.VehicleModelService.put(vehicle)
            if (response.status === 200) {
                runInAction(() => {
                    this.status = "success";
                })
            } 
        } catch (error) {
            runInAction(() => {
                this.status = "error";
            });
        }
    };
    deleteVehicleModelsAsync = async (id) => {
        try {
            const response = await this.VehicleModelService.delete(id);
            if (response.status === 204) {
                runInAction(() => {
                    this.status = "success";
                })
            } 
        } catch (error) {
            runInAction(() => {
                this.status = "error";
            });
        }
    }
}

decorate(VehicleModelStore, {
    vehicleModelData: observable,
    searchQuery: observable,
    status: observable
});
