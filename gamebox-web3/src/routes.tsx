import { Fragment } from "react"
import { Route, Switch, Redirect } from "react-router-dom"
import ScrollToTop from "./utils/scrollToTop"
import Home from "./pages/Home"

function Routes(): JSX.Element {
    return (
        <Fragment>
            <ScrollToTop />
            <Switch>
                <Route exact strict path="/" component={Home} />
                <Redirect to="/" />
            </Switch>
        </Fragment>
    )
}

export default Routes