//
//  Pokedex_TestApp.swift
//  Pokedex Test
//
//  Created by Martin on 28/07/23.
//

import SwiftUI


@main
struct Pokedex_TestApp: App {
    @StateObject private var pokedexViewModel = PokedexViewModel()

    var body: some Scene {
        WindowGroup {
            if pokedexViewModel.pokemonList.isEmpty {
                ProgressView()
                    .onAppear {
                        Task {
                            await pokedexViewModel.loadData()
                        }
                    }
            } else {
                ContentView()
                    .environmentObject(pokedexViewModel)
            }
        }
    }
}

