//
//  ContentView.swift
//  Pokedex Test
//
//  Created by Martin on 28/07/23.
//

import SwiftUI

struct ContentView: View {
    
    @StateObject var viewModel = ContentViewModel()
    @StateObject var registrationViewModel = RegisterViewModel()
    
    var body: some View {
        Group {
            if viewModel.userSession == nil {
                SignInView()
            } else if let currentUser = viewModel.userSession{
                PokedexView(user: currentUser)
            }
        }
    }
}

struct ContentView_Previews: PreviewProvider {
    static var previews: some View {
        ContentView()
    }
}
