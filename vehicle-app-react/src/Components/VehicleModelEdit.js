import * as React from 'react';
import { observer, inject } from 'mobx-react';
import { Link } from "react-router-dom";
import { Form, FormGroup, Input, Button } from "reactstrap";

class VehicleModelEdit extends React.Component {
    VehicleModelEdit = (e) => {
        e.preventDefault();
        this.props.VehicleModelStore.updateVehicleModelsAsync({
            name: this.refs.name.value,
            abrv: this.refs.abrv.value,
        });
        this.refs.name.value = null;
        this.refs.abrv.value = null;
    };
    render() {
        return (
            <Form onChange={this.VehicleModelEdit}>
            <FormGroup>
                <Input type="text" id="name" name="name" placeholder="Name" required></Input>
            </FormGroup>
            <FormGroup>
                <Input type="text" id="abrv" name="abrv" placeholder="Abrv" required></Input>
            </FormGroup>
            <FormGroup>
                <Input type="text" id="makeId" name="makeId" placeholder="Make Id" required></Input>
            </FormGroup>
            <Button onClick={this.EditVehicleModel}>Edit</Button>
            <Link to="/vehicleModelList" className="btn btn-danger ml-2">Cancel</Link>
            </Form>
        )
    }
}

export default inject("VehicleModelStore")(observer(VehicleModelEdit)); 