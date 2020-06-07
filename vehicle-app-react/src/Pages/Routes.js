import React from 'react';
import { BrowserRouter as Router, Switch, Route} from 'react-router-dom';
import VehicleMakeList from '../Components/VehicleMakeList';
import VehicleMakeCreate from '../Components/VehicleMakeCreate';
import VehicleMakeEdit from '../Components/VehicleMakeEdit';
import VehicleMakeDelete from '../Components/VehicleMakeDelete';
import VehicleModelList from '../Components/VehicleModelList';
import VehicleModelCreate from '../Components/VehicleModelCreate';
import VehicleModelEdit from '../Components/VehicleModelEdit';
import VehicleModelDelete from '../Components/VehicleModelDelete';

export default function Routes(){
        return(
        <Router>
        <Switch>
          <Route exact path="/" component={VehicleMakeList} />  
          <Route path="/vehicleMakeCreate" component={VehicleMakeCreate} />
          <Route path="/vehicleMakeEdit/:id" component={VehicleMakeEdit} />
          <Route path="/vehicleMakeDelete/:id" component={VehicleMakeDelete} />
          <Route path="/vehicleModelList" component={VehicleModelList} />
          <Route path="/vehicleModelCreate" component={VehicleModelCreate} />
          <Route path="/vehicleModelEdit/:id" component={VehicleModelEdit} />
          <Route path="/vehicleModelDelete/:id" component={VehicleModelDelete} />
        </Switch>
        </Router>
        )
    }