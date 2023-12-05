//
//  PokedexViewModel.swift
//  Pokedex Test
//
//  Created by Martin on 05/11/23.
//

import Foundation

class PokedexViewModel: ObservableObject {
    @Published var pokemonList: [Pokemon] = []
    
    init() {}
    
    func loadData() async {
        PokeAPI().getPokemonList() { pokemon in
            self.pokemonList = pokemon
        }
    }
}
