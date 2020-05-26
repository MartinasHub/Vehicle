import * as React from 'react';
import { observer, inject } from 'mobx-react';

class VehicleMakeList extends React.Component{
    
    componentDidMount() {
        this.props.VehicleMakeStore.getVehicleMakesAsync();
    }

    searchVehicleMakes = (e) => {
        if(e.key === "Enter") {
            this.props.VehicleMakeStore.search = e.target.value;
        }
    }

    sortVehicleMakes = () => {
        this.props.VehicleMakeStore.vehicleMakeData.isAscending = this.props.VehicleMakeStore.vehicleMakeData.isAscending 
        ? false : true
        this.props.VehicleMakeStore.getVehicleMakesAsync()
    }

    render(){
        return (
            <div>
                <input type="search" placeholder="Search" onKeyPress={this.searchVehicleMakes} />
                <input type="submit" value="Sort" onClick={this.sortVehicleMakes}/>

                <table>
                    <thead>
                        <tr>
                            <th>Name</th>
                            <th>Abrv</th>
                        </tr>
                    </thead>
                <tbody>
                    {this.props.VehicleMakeStore.vehicleMakeData.model.map
                    (vehicleMakes => (
                        <tr key={vehicleMakes.id}>
                            <td>{vehicleMakes.name}</td>
                            <td>{vehicleMakes.abrv}</td>
                        </tr>
                    ))}
                </tbody>
                </table>
            </div>
        )
    }
}

export default inject("VehicleMakeStore")(observer(VehicleMakeList));

class Create extends React.Component {
    CreateVehicleMake = (e) => {
        e.preventDefault();
        this.props.VehicleMakeStore.createVehicleMakesAsync({
            name: this.refs.name.value,
            abrv: this.refs.abrv.value,
        });
        this.refs.name.value = null;
        this.refs.abrv.value = null;
    };
    render() {
        return (
            <div>
                <div>
                    <form onSubmit={this.CreateVehicleMake}>
                    <div className="form-group">
                        <input ref="name" id="name" type="text" placeholder="Name"/>
                    </div>
                    <div className="form-group">
                        <input ref="abrv" id="abrv" type="text" placeholder="Abrv"/>
                    </div>
                        <button type="submit">Save</button>
                    </form>
                </div>
            </div>
        )
    }
}

export default inject("VehicleMakeStore")(observer(Create)); 

Delete = (e) => {
    e.preventDefault();
    this.props.VehicleMakeStore.deleteVehicleMakesAsync(this.props.id)
}