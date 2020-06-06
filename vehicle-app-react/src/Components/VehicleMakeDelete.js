import * as React from 'react';
import { observer, inject } from 'mobx-react';

class Delete extends React.Component {
    VehicleMakeDelete = (e) => {
        e.preventDefault();
        this.props.VehicleMakeStore(this.props.id)
    }
}

export default inject("VehicleMakeStore")(observer(Delete)); 