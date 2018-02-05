import * as React from 'react';
import { Route } from 'react-router-dom';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { AssetData } from './components/AssetData';
import { FundData } from './components/FundData';
import { SearchAssetData } from './components/SearchAssetData';

export const routes = <Layout>
    <Route exact path='/' component={Home} />
    <Route path='/assetdata' component={AssetData} />
    <Route path='/funddata' component={FundData} />
    <Route path='/searchassetdata' component={SearchAssetData} />
</Layout>;
