import * as React from 'react';
import { observer, inject } from 'mobx-react';
import { Table, Input, Button } from 'reactstrap';

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
                <div className="row form-group">
                <div className="input-group mb-3">
                <Input type="text" className="form-control" placeholder="Search" />
                <div className="input-group-append">
                <Button type="submit" onClick={this.searchVehicleMakes} color="primary">Search</Button>
                </div>
                </div>
                <div className="col text-center">
                <Button type="submit" onClick={this.sortVehicleMakes} color="info">Sort</Button>
                </div>
                </div>
                <br />
            <Table className="table table-hover">
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
                </Table>
            </div>
        )
    }
}

export default inject("VehicleMakeStore")(observer(VehicleMakeList));