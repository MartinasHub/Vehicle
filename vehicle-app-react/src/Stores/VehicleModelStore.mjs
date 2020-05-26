import { observable, runInAction, decorate } from 'mobx';
import VehicleModelService from './Common/VehicleModelService';

class VehicleModelStore {
constructor(){
    this.vehicleModelService = new VehicleModelService();
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
            const data = await this.vehicleModelService.get(urlParams)
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
            const response = await this.vehicleModelService.post(model);
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
            const response = await this.vehicleModelService.put(vehicle)
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
            const response = await this.vehicleModelService.delete(id);
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

export default new VehicleModelStore();