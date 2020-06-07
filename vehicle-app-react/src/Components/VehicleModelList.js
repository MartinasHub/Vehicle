import * as React from 'react';
import { observer, inject } from 'mobx-react';
import { Table, Input, Button } from 'reactstrap';

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
                <div className="row form-group">
                <div className="input-group mb-3">
                <Input type="text" className="form-control" placeholder="Search" />
                <div className="input-group-append">
                <Button type="submit" onClick={this.searchVehicleModels} color="primary">Search</Button>
                </div>
                </div>
                <div className="col text-center">
                <Button type="submit" onClick={this.sortVehicleModels} color="info">Sort</Button>
                </div>
                </div>
                <br />
                <Table className="table table-hover">
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
                </Table>
            </div>
        )
    }
}

export default inject("VehicleModelStore")(observer(VehicleModelList));