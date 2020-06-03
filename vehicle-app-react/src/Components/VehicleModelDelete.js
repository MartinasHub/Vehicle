import * as React from 'react';
import { observer, inject } from 'mobx-react';

class Delete extends React.Component {
    Delete = (e) => {
        e.preventDefault();
        this.props.VehicleModelStore(this.props.id)
    }
}

export default inject("VehicleModelStore")(observer(Delete)); 