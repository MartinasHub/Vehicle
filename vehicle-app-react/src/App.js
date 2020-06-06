import React from 'react';
import './Layouts/App.css';
import { BrowserRouter as Router, Switch, Route} from 'react-router-dom';
import { VehicleMakeCreate } from './Components/VehicleMakeCreate';
import { VehicleMakeEdit } from './Components/VehicleMakeEdit';
import { VehicleMakeDelete} from './Components/VehicleMakeDelete';
import { VehicleModelList } from './Components/VehicleModelList';
import { VehicleModelCreate } from './Components/VehicleModelCreate';
import { VehicleModelEdit } from './Components/VehicleModelEdit';
import { VehicleModelDelete} from './Components/VehicleModelDelete';
import { VehicleMakeList } from './Components/VehicleMakeList';

import 'bootstrap/dist/css/bootstrap.min.css'

function App () {
  return(
    <div className="App">
      <header className="App-header">
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
      </header>
    </div>
  )
}

export default App;
