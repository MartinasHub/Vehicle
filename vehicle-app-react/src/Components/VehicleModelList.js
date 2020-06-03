import * as React from 'react';
import { observer, inject } from 'mobx-react';

class VehicleModelList extends React.Component{
    
    componentDidMount() {
        this.props.VehicleModelStore.getVehicleModelsAsync();
    }

    searchVehicleModels = (e) => {
        if(e.key === "Enter") {
            this.props.VehicleModelStore.search = e.target.value;
        }
    }

    sortVehicleModels = () => {
        this.props.VehicleModelStore.vehicleModelData.isAscending = this.props.VehicleModelStore.vehicleModelData.isAscending 
        ? false : true
        this.props.VehicleModelStore.getVehicleModelsAsync()
    }

    render(){
        return (
            <div>
                <input type="search" placeholder="Search" onKeyPress={this.searchVehicleModels} />
                <input type="submit" value="Sort" onClick={this.sortVehicleModels}/>

                <table>
                    <thead>
                        <tr>
                            <th>Name</th>
                            <th>Abrv</th>
                            <th>Vehicle</th>
                        </tr>
                    </thead>
                <tbody>
                    {this.props.VehicleModelStore.vehicleModelData.model.map
                    (vehicleModels => (
                        <tr key={vehicleModels.id}>
                            <td>{vehicleModels.name}</td>
                            <td>{vehicleModels.abrv}</td>
                            <td>{vehicleModels.makeId.name}</td>
                        </tr>
                    ))}
                </tbody>
                </table>
            </div>
        )
    }
}

export default inject("VehicleModelStore")(observer(VehicleModelList));