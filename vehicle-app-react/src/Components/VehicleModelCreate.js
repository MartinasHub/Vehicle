import * as React from 'react';
import { observer, inject } from 'mobx-react';
import { Form, FormGroup, Input, Button } from 'reactstrap';
import { Link } from 'react-router-dom';

class VehicleModelCreate extends React.Component {
    VehicleModelCreate = (e) => {
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
            <Form onSubmit={this.VehicleModelCreate}>
            <FormGroup>
                <Input type="text" id="name" name="name" placeholder="Name" required></Input>
            </FormGroup>
            <FormGroup>
                <Input type="text" id="abrv" name="abrv" placeholder="Abrv" required></Input>
            </FormGroup>
            <FormGroup>
                <Input type="text" id="makeId" name="makeId" placeholder="MakeId" required></Input>
            </FormGroup>
            <Button type="submit">Submit</Button>
            <Link to="/vehicleModelList" className="btn btn-danger ml-2">Cancel</Link>
            </Form>
        )
    }
}

export default inject("VehicleModelStore")(observer(VehicleModelCreate)); 