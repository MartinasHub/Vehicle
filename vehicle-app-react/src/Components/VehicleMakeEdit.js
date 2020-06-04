import * as React from 'react';
import { observer, inject } from 'mobx-react';

class Edit extends React.Component {
    EditVehicleMake = (e) => {
        e.preventDefault();
        this.props.VehicleMakeStore.editVehicleMakesAsync({
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
                    <form onChange={this.EditVehicleMake}>
                    <div className="form-group">
                        <input ref="name" id="name" type="text" placeholder="Name"/>
                    </div>
                    <div className="form-group">
                        <input ref="abrv" id="abrv" type="text" placeholder="Abrv"/>
                    </div>
                        <button onClick={this.EditVehicleMake}>Edit</button>
                    </form>
                </div>
            </div>
        )
    }
}

export default inject("VehicleMakeStore")(observer(Edit)); 