import * as React from 'react';
import { observer, inject } from 'mobx-react';

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
            <div>
                <div>
                    <form onSubmit={this.VehicleModelCreate}>
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

export default inject("VehicleModelStore")(observer(VehicleModelCreate)); 