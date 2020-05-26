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

class Create extends React.Component {
    CreateVehicleModel = (e) => {
        e.preventDefault();
        this.props.VehicleModelStore.createVehicleModelsAsync({
            name: this.refs.name.value,
            abrv: this.refs.abrv.value,
            makeId: this.refs.makeId.value,
        });
        this.refs.name.value = null;
        this.refs.abrv.value = null;
        this.refs.makeId.value = null;
    };
    render() {
        return (
            <div>
                <div>
                    <form onSubmit={this.CreateVehicleModel}>
                    <div className="form-group">
                        <input ref="name" id="name" type="text" placeholder="Name"/>
                    </div>
                    <div className="form-group">
                        <input ref="abrv" id="abrv" type="text" placeholder="Abrv"/>
                    </div>
                    <div className="form-group">
                        <input ref="makeId" id="makeId" type="text" placeholder="Vehicle"/>
                    </div>
                        <button type="submit">Save</button>
                    </form>
                </div>
            </div>
        )
    }
}

export default inject("VehicleModelStore")(observer(Create)); 

Delete = (e) => {
    e.preventDefault();
    this.props.VehicleMakeStore.deleteVehicleModelsAsync(this.props.id)
}