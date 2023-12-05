//
//  ChangePokemonView.swift
//  Pokedex Test
//
//  Created by Martin on 14/11/23.
//

import SwiftUI

struct ChangePokemonView: View {
    let poke: Pokemon
    
    var body: some View {
        ZStack {
            RoundedRectangle(cornerRadius: 9)
                .frame(width: 64, height: 120)
                .foregroundColor(Color.fromString(poke.color) ?? .red)
                .shadow(color: .gray.opacity(0.2), radius: 5, x: 0, y: 0)
                .overlay {
                    Image("mr mime")
                        .resizable()
                        .frame(width: 120, height: 120)
                }
                .mask(RoundedRectangle(cornerRadius: 20))
        }
    }
}

struct ChangePokemonView_Previews: PreviewProvider {
    static var previews: some View {
        ChangePokemonView(poke: Pokemon.MOCK_POKEMON[2])
    }
}
