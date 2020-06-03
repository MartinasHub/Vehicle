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