import { observable, runInAction, decorate } from 'mobx';
import VehicleMakeService from './Common/VehicleMakeService';

class VehicleMakeStore {
constructor(){
    this.vehicleMakeService = new VehicleMakeService();
}
    vehicleMakeData = {
        model: []
    };
    status = "initial";
    searchQuery = "";

    getVehicleMakesAsync = async () => {
        try {
            var params = {
                pageNumber: this.vehicleMakeData.pageNumber,
                searchQuery: this.searchQuery,
                isAscending: this.vehicleMakeData.isAscending
            };
            const urlParams = new URLSearchParams(Object.entries(params));
            const data = await this.vehicleMakeService.get(urlParams)
            runInAction(() => {
                this.vehicleMakeData = data;
            });
        } catch (error) {
            runInAction(() => {
                this.status = "error";
            });
        }
    };
    createVehicleMakesAsync = async (model) => {
        try {
            const response = await this.vehicleMakeService.post(model);
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
    updateVehicleMakesAsync = async (vehicle) => {
        try {
            const response = await this.vehicleMakeService.put(vehicle)
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
    deleteVehicleMakeAsync = async (id) => {
        try {
            const response = await this.vehicleMakeService.delete(id);
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

decorate(VehicleMakeStore, {
    vehicleMakeData: observable,
    searchQuery: observable,
    status: observable
});

export default new VehicleMakeStore();