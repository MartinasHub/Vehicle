import * as React from 'react';
import { observer, inject } from 'mobx-react';

class VehicleMakeCreate extends React.Component {
    VehicleMakeCreate = (e) => {
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
                    <form onSubmit={this.VehicleMakeCreate}>
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

export default inject("VehicleMakeStore")(observer(VehicleMakeCreate)); 