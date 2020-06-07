import * as React from 'react';
import { observer, inject } from 'mobx-react';
import { Link } from "react-router-dom";
import { Form, FormGroup, Input, Button } from "reactstrap";

class VehicleMakeEdit extends React.Component {
    VehicleMakeEdit = (e) => {
        e.preventDefault();
        this.props.VehicleMakeStore.updateVehicleMakesAsync({
            name: this.refs.name.value,
            abrv: this.refs.abrv.value,
        });
        this.refs.name.value = null;
        this.refs.abrv.value = null;
    };
    render() {
        return (
            <Form onChange={this.VehicleMakeEdit}>
            <FormGroup>
                <Input type="text" id="name" name="name" placeholder="Name" required></Input>
            </FormGroup>
            <FormGroup>
                <Input type="text" id="abrv" name="abrv" placeholder="Abrv" required></Input>
            </FormGroup>
            <Button onClick={this.VehicleMakeEdit}>Edit</Button>
            <Link to="/" className="btn btn-danger ml-2">Cancel</Link>
            </Form>
        )
    }
}

export default inject("VehicleMakeStore")(observer(VehicleMakeEdit)); 