//
//  PokemonHP.swift
//  Pokedex Test
//
//  Created by Martin on 16/11/23.
//

import SwiftUI

struct PokemonHP: View {
    var body: some View {
        VStack {
            HStack {
                Image(systemName: "heart.fill")
                    .resizable()
                    .frame(width: 15, height: 15)
                    .clipped()
                    .foregroundColor(.red)
                
                Text("120/140")
                    .font(.custom("GILROY-SEMIBOLD", size: 18))
            }
            
        }
    }
}

#Preview {
    PokemonHP()
}
